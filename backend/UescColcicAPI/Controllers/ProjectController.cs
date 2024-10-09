using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UescColcicAPI.Services.BD.Interfaces;
using UescColcicAPI.Core;
using Microsoft.AspNetCore.Http.HttpResults;

namespace UescColcicAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProjectsController : ControllerBase
    {
        private readonly IProjectCRUD _projectCRUD;

        public ProjectsController(IProjectCRUD projectCRUD)
        {
            _projectCRUD = projectCRUD;
        }

        [HttpPost(Name = "CreateProject")]
        public IActionResult Post([FromBody] Project project)
        {
            if (project == null)
            {
                return BadRequest();
            }

            _projectCRUD.Create(project);
            return CreatedAtAction(nameof(Get), new { id = project.ProjectId }, project);
        }

        [HttpGet(Name = "GetProjects")]
        public IEnumerable<Project> Get()
        {
            return _projectCRUD.ReadAll();
        }

        [HttpGet("{id}", Name = "GetProject")]
        public ActionResult<Project> Get(int id)
        {
            var project = _projectCRUD.ReadById(id);
            if (project == null)
            {
                return NotFound($"Project with ID {id} not found.");
            }
            return Ok(project);
        }

        [HttpPut(Name = "UpdateProject")]
        public IActionResult Update([FromBody] Project project)
        {
            if (project == null)
            {
                return BadRequest();
            }

            _projectCRUD.Update(project);
            return NoContent(); // 204 No Content
        }

        [HttpDelete("{id}", Name = "DeleteProject")]
        public IActionResult Delete(int id)
        {
            var project = _projectCRUD.ReadById(id);
            if (project == null)
            {
                return NotFound($"Project with ID {id} not found.");
            }

            _projectCRUD.Delete(project);
            return NoContent(); // 204 No Content
        }

        // Adiciona uma skill ao projeto
        [HttpPost("{projectId}/skill", Name = "AddSkillToProject")]
        public IActionResult AddSkillToProject(int projectId,  int skillId, int weight)
        {
            _projectCRUD.AddSkillToProject(projectId, skillId, weight);
            return CreatedAtAction(nameof(ReadAllSkillsInProject), new { projectId }, null);
        }

        // Lê todas as skill associadas a um projeto
        [HttpGet("{projectId}/skill", Name = "ReadAllSkillsInProject")]
        public IActionResult ReadAllSkillsInProject(int projectId)
        {
            var skills = _projectCRUD.ReadAllSkillsInProject(projectId);
            if (skills == null || !skills.Any())
            {
                return NotFound($"No skills found for project with ID {projectId}.");
            }
            return Ok(skills);
        }

        // Remove uma skill do projeto
        [HttpDelete("{projectId}/skill/{skillId}", Name = "RemoveSkillFromProject")]
        public IActionResult RemoveSkillFromProject(int projectId, int skillId)
        {
            _projectCRUD.RemoveSkillFromProject(projectId, skillId);
            return NoContent(); // 204 No Content
        }

        // Atualiza uma skill do projeto
        [HttpPut("{projectId}/skill/{skillId}", Name = "UpdateSkillInProject")]
        public IActionResult UpdateSkillInProject(int projectId, int skillId, int weight)
        {
            _projectCRUD.UpdateSkillInProject(projectId, skillId, weight);
            return NoContent(); // 204 No Content
        }
    }
}
