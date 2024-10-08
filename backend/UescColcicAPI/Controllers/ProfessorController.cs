using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UescColcicAPI.Services.BD.Interfaces;
using UescColcicAPI.Core;
using System.Collections.Generic;
using System.Linq;

namespace UescColcicAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfessorsController : ControllerBase
    {
        private readonly IProfessorCRUD _professorCRUD;

        public ProfessorsController(IProfessorCRUD professorCRUD)
        {
            _professorCRUD = professorCRUD;
        }

        [HttpPost(Name = "CreateProfessor")]
        public IActionResult Post([FromBody] Professor professor)
        {
            if (professor == null)
            {
                return BadRequest();
            }

            _professorCRUD.Create(professor);
            return CreatedAtAction(nameof(Get), new { id = professor.ProfessorId }, professor);
        }

        [HttpGet(Name = "GetProfessors")]
        public IEnumerable<Professor> Get()
        {
            return _professorCRUD.ReadAll();
        }

        [HttpGet("{id}", Name = "GetProfessor")]
        public ActionResult<Professor> Get(int id)
        {
            var professor = _professorCRUD.ReadById(id);
            if (professor == null)
            {
                return NotFound($"Professor with ID {id} not found.");
            }
            return Ok(professor);
        }

        [HttpPut(Name = "UpdateProfessor")]
        public IActionResult Update([FromBody] Professor professor)
        {
            if (professor == null)
            {
                return BadRequest();
            }

            _professorCRUD.Update(professor);
            return NoContent(); // 204 No Content
        }

        [HttpDelete("{id}", Name = "DeleteProfessor")]
        public IActionResult Delete(int id)
        {
            var professor = _professorCRUD.ReadById(id);
            if (professor == null)
            {
                return NotFound($"Professor with ID {id} not found.");
            }

            _professorCRUD.Delete(professor);
            return NoContent(); // 204 No Content
        }

        // Adiciona um student ao professor
        [HttpPost("{professorId}/student/{studentId}", Name = "AddStudentToProfessor")]
        public IActionResult AddStudentToProfessor(int professorId, int studentId)
        {
            _professorCRUD.AddStudentToProfessor(professorId, studentId);
            return NoContent(); // 204 No Content
        }

        // Remove um student do professor
        [HttpDelete("{professorId}/student/{studentId}", Name = "RemoveStudentFromProfessor")]
        public IActionResult RemoveStudentFromProfessor(int professorId, int studentId)
        {
            _professorCRUD.RemoveStudentFromProfessor(professorId, studentId);
            return NoContent(); // 204 No Content
        }

        // Lê todos os students associados a um professor
        [HttpGet("{professorId}/students", Name = "GetAllStudentsOfProfessor")]
        public IActionResult ReadAllStudentsOfProfessor(int professorId)
        {
            var students = _professorCRUD.ReadAllStudentsOfProfessor(professorId);
            if (students == null || !students.Any())
            {
                return NotFound($"No students found for professor with ID {professorId}.");
            }
            return Ok(students);
        }

        // Adiciona um project ao professor
        [HttpPost("{professorId}/project/{projectId}", Name = "AddProjectToProfessor")]
        public IActionResult AddProjectToProfessor(int professorId, int projectId)
        {
            _professorCRUD.AddProjectToProfessor(professorId, projectId);
            return NoContent(); // 204 No Content
        }

        // Remove um project do professor
        [HttpDelete("{professorId}/project/{projectId}", Name = "RemoveProjectFromProfessor")]
        public IActionResult RemoveProjectFromProfessor(int professorId, int projectId)
        {
            _professorCRUD.RemoveProjectFromProfessor(professorId, projectId);
            return NoContent(); // 204 No Content
        }

        // Lê todos os projects associados a um professor
        [HttpGet("{professorId}/projects", Name = "GetAllProjectsOfProfessor")]
        public IActionResult ReadAllProjectsOfProfessor(int professorId)
        {
            var projects = _professorCRUD.ReadAllProjectsOfProfessor(professorId);
            if (projects == null || !projects.Any())
            {
                return NotFound($"No projects found for professor with ID {professorId}.");
            }
            return Ok(projects);
        }
    }
}
