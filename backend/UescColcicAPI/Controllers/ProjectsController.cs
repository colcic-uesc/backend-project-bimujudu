
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UescColcicAPI.Services.BD.Interfaces;
using UescColcicAPI.Core;

namespace UescColcicAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProjectsController : ControllerBase
{
    private readonly IProjectsCRUD _projectsCRUD;

    public ProjectsController(IProjectsCRUD projectsCRUD)
    {
        _projectsCRUD = projectsCRUD;
    }

    [HttpGet(Name = "GetProjects")]
    public IEnumerable<Project> Get()
    {
        return _projectsCRUD.ReadAll();
    }

    [HttpGet("{ProjectId}", Name = "GetSProject")]
    public ActionResult<Project> Get(int id)
    {
        try
        {
            var project = _projectsCRUD.ReadById(id);
            if (project == null)
            {
                return NotFound($"Project with ID {id} not found.");
            }
            return Ok(project);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpPut(Name = "UpdateProject")]
    public void Update(Project project)
    {
        _projectsCRUD.Update(project);
    }

    [HttpDelete(Name = "DeleteProject")]
    public void Delete(Project entity)
    {
        _projectsCRUD.Delete(entity);
    }
}