using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UescColcicAPI.Services.BD.Interfaces;
using UescColcicAPI.Core;
using Microsoft.AspNetCore.Http.HttpResults;

namespace UescColcicAPI.Controllers;

    [ApiController]
    [Route("api/[controller]")]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentsCRUD _studentsCRUD;

        public StudentsController(IStudentsCRUD studentsCRUD)
        {
            _studentsCRUD = studentsCRUD;
        }

        [HttpPost(Name = "CreateStudent")]
        public IActionResult Post([FromBody] Student student)
        {
            if (student == null)
            {
                return BadRequest();
            }

            _studentsCRUD.Create(student);

            return CreatedAtAction(nameof(Get), new { id = student.StudentId }, student);
        }
       
        [HttpGet(Name = "GetStudents")]
        public IEnumerable<Student> Get()
        {
            return _studentsCRUD.ReadAll();
        }

        [HttpGet("{id}", Name = "GetStudent")]
        public ActionResult<Student> Get(int id)
        {
            try
            {
                var student = _studentsCRUD.ReadById(id);
                if (student == null)
                {
                    return NotFound($"Student with ID {id} not found.");
                }
                return Ok(student);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut(Name = "UpdateStudent")]
        public void Update(Student student)
        {
            _studentsCRUD.Update(student);

        }

        [HttpDelete(Name = "DeleteStudent")]
        public void Delete(Student entity)
        {
            _studentsCRUD.Delete(entity);
        }

        [HttpPost("{studentId}/skill", Name = "CreateStudentSkill")]
        public IActionResult AddSkillToStudent(int skillId, int weight ,int studentId)
        {
            _studentsCRUD.AddSkillToStudent(studentId, skillId, weight);
            return Created();
        }

        [HttpGet("{studentId}/skill", Name = "GetStudentSkill")]
        public IActionResult ReadAllSkillsToStudent(int studentId)
        {
            var skills = _studentsCRUD.ReadAllSkillsToStudent(studentId);

            if (skills == null)
            {
                
                return BadRequest($"Student with ID {studentId} not found.");
            }

            return Ok(skills);  
        }

        [HttpDelete("{studentId}/skill", Name = "DeleteStudentSkill")]
        public void RemoveSkillToStudent(int studentId, int skillId){
            _studentsCRUD.RemoveSkillToStudent(studentId, skillId);
        }

        [HttpPut("{studentId}/skill", Name = "UpdateStudentSkill")]
        public void UpdateSkillToStudent(int studentId, int skillId, int weight){
            _studentsCRUD.UpdateSkillToStudent(studentId, skillId, weight);
        }
    }
