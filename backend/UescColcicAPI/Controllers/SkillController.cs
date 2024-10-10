using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UescColcicAPI.Services.BD.Interfaces;
using UescColcicAPI.Core;
using Microsoft.AspNetCore.Http.HttpResults;

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

        [HttpPost(Name = "CreateSkill")]
        public IActionResult Post([FromBody] Skill skill)
        {
            if (skill == null)
            {
                return BadRequest();
            }

            _skillsCRUD.Create(skill);

            return CreatedAtAction(nameof(Get), new { id = skill.SkillId }, skill);
        }
       
        [HttpGet(Name = "GetSkills")]
        public IEnumerable<Skill> Get()
        {
            return _skillsCRUD.ReadAll();
        }

        [HttpGet("{id}", Name = "GetSkill")]
        public ActionResult<Skill> Get(int id)
        {
            try
            {
                var skill = _skillsCRUD.ReadById(id);
                if (skill == null)
                {
                    return NotFound($"Student with ID {id} not found.");
                }
                return Ok(skill);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut(Name = "UpdateSkill")]
        public ActionResult<Skill> Update(Skill skill)
        {
            if (skill == null)
            {
                return BadRequest("Skill is null.");
            }

            _skillsCRUD.Update(skill);
            return Ok(skill);
        }

        [HttpDelete(Name = "DeleteSkill")]
        public IActionResult Delete(Skill entity)
        {
            if (entity == null)
            {
                return BadRequest("Skill is null.");
            }

            _skillsCRUD.Delete(entity);
            return Ok();
        }

    }
