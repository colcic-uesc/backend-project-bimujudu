
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UescColcicAPI.Services.BD.Interfaces;
using UescColcicAPI.Core;

namespace UescColcicAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProfessorsController : ControllerBase
{
    private readonly IProfessorsCRUD _professorsCRUD;

    public ProfessorsController(IProfessorsCRUD professorsCRUD)
    {
        _professorsCRUD = professorsCRUD;
    }

    [HttpGet(Name = "GetProfessors")]
    public IEnumerable<Professor> Get()
    {
        return _professorsCRUD.ReadAll();
    }

    [HttpGet("{professorId}", Name = "GetProfessor")]
    public ActionResult<Professor> Get(int id)
    {
        try
        {
            var professor = _professorsCRUD.ReadById(id);
            if (professor == null)
            {
                return NotFound($"Professor with ID {id} not found.");
            }
            return Ok(professor);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpPut(Name = "UpdateProfessor")]
    public void Update(Professor professor)
    {
        _professorsCRUD.Update(professor);
    }

    [HttpDelete(Name = "DeleteProfessor")]
    public void Delete(Professor entity)
    {
        _professorsCRUD.Delete(entity);
    }

    [HttpPost(Name = "PostProfessor")]
    public IActionResult Create([FromBody] Professor professor)
    {
        _professorsCRUD.Create(professor);
        return CreatedAtAction(nameof(Get), new { id = professor.ProfessorId }, professor);
    }

    [HttpPost("{professorId}/Projects", Name = "AddProjectToProfessor")]
    public void AddProjectToProfessor(int professorID, Project[] entity){
            _professorsCRUD.AddProjectToProfessor(professorID, entity);
    }

    [HttpDelete("{professorId}/Projects", Name = "DeleteProjectToProfessor")]
    public void DeleteProjectToProfessor(int professorID, Project[] entity){
        _professorsCRUD.DeleteProjectToProfessor(professorID, entity);
    }
}