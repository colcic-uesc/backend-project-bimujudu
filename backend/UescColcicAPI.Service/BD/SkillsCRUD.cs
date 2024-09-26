using UescColcicAPI.Services.BD.Interfaces;
using UescColcicAPI.Core;

namespace UescColcicAPI.Services.BD;

public class SkillsCRUD : ISkillsCRUD
{
    private static readonly List<Skill> Skills = new()
    {
        new Skill { SkillId = 1, Title = "Python", Description = "Proficiência em programação com linguagem Python." },
        new Skill { SkillId = 2, Title = "Django",  Description = "Conhecimento em backend utilizando framework Django." },
        new Skill { SkillId = 3, Title = "MySQL", Description = "Proficiência em consulta de dados com MySQL." },
        new Skill { SkillId = 4, Title = "Machine Learning.",  Description = "Conhecimento de algoritmos de Machine Learning." }
    };

    public void Create(Skill entity)
    {
        var skill = this.Find(entity.SkillId);
        if(skill is null)
            Skills.Add(entity);
    }

    public void Delete(Skill entity)
    {
        StudentsCRUD studentsCRUD = new(); 
        var students = studentsCRUD.ReadAll();
        ProjectsCRUD projectsCRUD = new();
        var projects = projectsCRUD.ReadAll();
        var skill = this.Find(entity.SkillId);

        if (skill is not null){
             // Remover a skill da lista de cada estudante
                foreach (var student in students)
                {
                    if (student.Skills != null && student.Skills.Any(s => s.SkillId == entity.SkillId))
                    {
                        // Remove a skill da lista de skills do estudante
                        student.Skills.RemoveAll(s => s.SkillId == entity.SkillId);
                    }
                }

                //Remover a skill da lista de cada projeto
                foreach (var project in projects)
                {
                    if (project.Skills != null && project.Skills.Any(s => s.SkillId == entity.SkillId))
                    {
                        // Remove a skill da lista de skills do projeto
                        project.Skills.RemoveAll(s => s.SkillId == entity.SkillId);
                    }
                }
                //Remover a skill da lista de skills principal
                Skills.Remove(skill);
        }
        
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
        var skill = this.Find(entity.SkillId);
        if (skill is not null)
        {
            skill.Title = entity.Title;
            skill.Description = entity.Description;
        }
    }


    private Skill? Find(int id)
    {
        return Skills.FirstOrDefault(x => x.SkillId == id);
    }
}