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

       
        [HttpGet(Name = "GetStudents")]
        public IEnumerable<Student> Get()
        {
            return _studentsCRUD.ReadAll();
        }

        [HttpGet("{studentId}", Name = "GetStudent")]
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

        [HttpPost(Name = "PostStudent")]
        public IActionResult Create([FromBody] Student student)
        {
            _studentsCRUD.Create(student);
            return CreatedAtAction(nameof(Get), new { id = student.StudentId }, student);
        }

        [HttpPost("{studentId}/Skills", Name = "AddSkillToStudent")]
        public void AddSkillToStudent(int id, Skill[] entity){
            _studentsCRUD.AddSkillToStudent(id, entity);
        }

        [HttpDelete("{studentId}/Skills", Name = "DeleteSkillToStudent")]
        public void DeleteSkillToStudent(int id, Skill[] entity){
            _studentsCRUD.DeleteSkillToStudent(id, entity);
        }
    }