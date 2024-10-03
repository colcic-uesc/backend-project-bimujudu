using UescColcicAPI.Services.BD.Interfaces;
using UescColcicAPI.Core;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;

namespace UescColcicAPI.Services.BD;

public class SkillsCRUD : ISkillsCRUD
{
    private UescColcicDBContext _context;
   public SkillsCRUD(UescColcicDBContext context){
        _context = context;
   }
    public void Create(Skill entity)
    {
        _context.Skills.Add(entity);
        _context.SaveChanges();
    }

    public void Delete(Skill entity)
    {   
        var skill = this.Find(entity.SkillId);
        if(skill is not null){
            _context.Skills.Remove(skill);
            _context.SaveChanges();
        }
    }

    public IEnumerable<Skill> ReadAll()
    {
        return _context.Skills.Include(s => s.StudentSkills);
    }

    public Skill? ReadById(int id)
    {
        var skill = this.Find(id);
        return skill;
    }

    public void Update(Skill entity)
    {
        var skill = this.Find(entity.SkillId);
        if(skill is not null)
        {
            skill.Description = entity.Description;
            skill.Title = entity.Title;
            _context.SaveChanges();
        }
    }

    private Skill? Find(int id)
    {
        return _context.Skills.Include(s => s.StudentSkills).FirstOrDefault(x => x.SkillId == id);
    }

}
