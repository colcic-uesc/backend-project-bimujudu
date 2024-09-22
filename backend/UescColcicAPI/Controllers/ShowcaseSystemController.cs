
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UescColcicAPI.Services.BD.Interfaces;
using UescColcicAPI.Core;

namespace UescColcicAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ShowcaseSystemController : ControllerBase
{
    private readonly IShowcaseSystemCRUD _crud;

    public ShowcaseSystemController(IShowcaseSystemCRUD ShowcaseSystemCRUD)
    {
        _crud = ShowcaseSystemCRUD;
    }

    // NEED TO IMPLEMENT
    
    // [HttpPost("addProfessor")]
    // public IActionResult AddProfessor([FromBody] Professor professor)
    // {
    //     _crud.AddProfessor(professor);
    //     return Ok("Professor added successfully");
    // }

    // [HttpPost("addStudent")]
    // public IActionResult AddStudent([FromBody] Student student)
    // {
    //     _crud.AddStudent(student);
    //     return Ok("Student added successfully");
    // }

    // [HttpPost("addProject")]
    // public IActionResult AddProject([FromBody] Project project)
    // {
    //     _crud.AddProject(project);
    //     return Ok("Project added successfully");
    // }

    // [HttpPost("addSkill")]
    // public IActionResult AddSkill([FromBody] Skill skill)
    // {
    //     _crud.AddSkill(skill);
    //     return Ok("Skill added successfully");
    // }

    // // READ Methods

    // [HttpGet("getProfessor/{id}")]
    // public IActionResult GetProfessor(int id)
    // {
    //     var professor = _crud.GetProfessor(id);
    //     if (professor == null)
    //         return NotFound("Professor not found");
    //     return Ok(professor);
    // }

    // [HttpGet("getStudent/{id}")]
    // public IActionResult GetStudent(int id)
    // {
    //     var student = _crud.GetStudent(id);
    //     if (student == null)
    //         return NotFound("Student not found");
    //     return Ok(student);
    // }

    // [HttpGet("getProject/{id}")]
    // public IActionResult GetProject(int id)
    // {
    //     var project = _crud.GetProject(id);
    //     if (project == null)
    //         return NotFound("Project not found");
    //     return Ok(project);
    // }

    // [HttpGet("getSkill/{id}")]
    // public IActionResult GetSkill(int id)
    // {
    //     var skill = _crud.GetSkill(id);
    //     if (skill == null)
    //         return NotFound("Skill not found");
    //     return Ok(skill);
    // }

    // // UPDATE Methods

    // [HttpPut("updateProfessor")]
    // public IActionResult UpdateProfessor([FromBody] Professor professor)
    // {
    //     _crud.UpdateProfessor(professor);
    //     return Ok("Professor updated successfully");
    // }

    // [HttpPut("updateStudent")]
    // public IActionResult UpdateStudent([FromBody] Student student)
    // {
    //     _crud.UpdateStudent(student);
    //     return Ok("Student updated successfully");
    // }

    // [HttpPut("updateProject")]
    // public IActionResult UpdateProject([FromBody] Project project)
    // {
    //     _crud.UpdateProject(project);
    //     return Ok("Project updated successfully");
    // }

    // [HttpPut("updateSkill")]
    // public IActionResult UpdateSkill([FromBody] Skill skill)
    // {
    //     _crud.UpdateSkill(skill);
    //     return Ok("Skill updated successfully");
    // }

    // // DELETE Methods

    // [HttpDelete("deleteProfessor/{id}")]
    // public IActionResult DeleteProfessor(int id)
    // {
    //     _crud.DeleteProfessor(id);
    //     return Ok("Professor deleted successfully");
    // }

    // [HttpDelete("deleteStudent/{id}")]
    // public IActionResult DeleteStudent(int id)
    // {
    //     _crud.DeleteStudent(id);
    //     return Ok("Student deleted successfully");
    // }

    // [HttpDelete("deleteProject/{id}")]
    // public IActionResult DeleteProject(int id)
    // {
    //     _crud.DeleteProject(id);
    //     return Ok("Project deleted successfully");
    // }

    // [HttpDelete("deleteSkill/{id}")]
    // public IActionResult DeleteSkill(int id)
    // {
    //     _crud.DeleteSkill(id);
    //     return Ok("Skill deleted successfully");
    // }
}