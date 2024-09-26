
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UescColcicAPI.Services.BD.Interfaces;
using UescColcicAPI.Core;

namespace UescColcicAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SkillsController : ControllerBase
{
    private readonly ISkillsCRUD _skillsCRUD;

    public SkillsController(ISkillsCRUD skillsCRUD)
    {
        _skillsCRUD = skillsCRUD;
    }

    [HttpGet(Name = "GetSkills")]
    public IEnumerable<Skill> Get()
    {
        return _skillsCRUD.ReadAll();
    }

    [HttpGet("{skillId}", Name = "GetSkill")]
    public ActionResult<Skill> Get(int id)
    {
        try
        {
            var skill = _skillsCRUD.ReadById(id);
            if (skill == null)
            {
                return NotFound($"Skill with ID {id} not found.");
            }
            return Ok(skill);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpPut(Name = "UpdateSkill")]
    public void Update(Skill skill)
    {
        _skillsCRUD.Update(skill);
    }

    [HttpDelete(Name = "DeleteSkill")]
    public void Delete(Skill entity)
    {
        _skillsCRUD.Delete(entity);
    }

    [HttpPost(Name = "PostSkill")]
    public IActionResult Create([FromBody] Skill skill)
    {
        _skillsCRUD.Create(skill);
        return CreatedAtAction(nameof(Get), new { id = skill.SkillId }, skill);
    }
}