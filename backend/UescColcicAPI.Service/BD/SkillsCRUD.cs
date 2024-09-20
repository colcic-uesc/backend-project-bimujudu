using UescColcicAPI.Services.BD.Interfaces;
using UescColcicAPI.Core;

namespace UescColcicAPI.Services.BD;

public class SkillsCRUD : ISkillsCRUD
{
    private static readonly List<Skill> Skills = new()
    {
        new Skill { skillId = 1, title = "blablabla", description = "AAAAAAAAAAAAAAAAAAAAAAAA" },
        new Skill { skillId = 2, title = "blablabla",  description = "bbbbbbbbbbbbbbbbbbbbbbbb" }
    };

    public void Create(Skill entity)
    {
        Skills.Add(entity);
    }

    public void Delete(Skill entity)
    {
        var skill = this.Find(entity.skillId);
        if (skill is not null)
            Skills.Remove(skill);
    }

    public IEnumerable<Skill> ReadAll()
    {
        return Skills;
    }

    public Skill? ReadById(int id)
    {
        var skill = this.Find(id);
        return skill;
    }

    public void Update(Skill entity)
    {
        var skill = this.Find(entity.skillId);
        if (skill is not null)
        {
            skill.title = entity.title;
            skill.description = entity.description;
        }
    }


    private Skill? Find(int id)
    {
        return Skills.FirstOrDefault(x => x.skillId == id);
    }
}