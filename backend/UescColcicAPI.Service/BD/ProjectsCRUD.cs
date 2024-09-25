
using UescColcicAPI.Services.BD.Interfaces;
using UescColcicAPI.Core;

namespace UescColcicAPI.Services.BD;

public class ProjectsCRUD : IProjectsCRUD
{
    private static readonly List<Project> Projects = new()
    {
        new Project { ProjectId = 1, Title = "IA na Educação", Description = "Projeto de IA aplicado a educação", Type = "Pesquisa", StartDate = DateTime.Now, EndDate = DateTime.Now.AddYears(1), ProfessorId = 1 },
        new Project { ProjectId = 2, Title = "Imagem e Ação", Description = "Pesquisa sobre processamento de imagens", Type = "Pesquisa", StartDate = DateTime.Now, EndDate = DateTime.Now.AddYears(1), ProfessorId = 2 },
        new Project { ProjectId = 3, Title = "Campeonato de Programação Universitário", Description = "Recrutamento para competições de programação", Type = "Projeto", StartDate = DateTime.Now, EndDate = DateTime.Now.AddYears(1), ProfessorId = 3},
        new Project { ProjectId = 4, Title = "Monitoria de Programação", Description = "Monitoria nas disciplinas de Linguagem de Programação", Type = "Monitoria", StartDate = DateTime.Now, EndDate = DateTime.Now.AddYears(1), ProfessorId = 4 }
    };

    public void Create(Project entity)
    {
        Projects.Add(entity);
    }

    public void Delete(Project entity)
    {
        var project = this.Find(entity.ProjectId);
        if (project is not null)
            Projects.Remove(project);
    }

    public IEnumerable<Project> ReadAll()
    {
        return Projects;
    }

    public Project? ReadById(int id)
    {
        var project = this.Find(id);
        return project;
    }

    public void Update(Project entity)
    {
        var project = this.Find(entity.ProjectId);
        if (project is not null)
        {
            project.Title = entity.Title;
            project.Description = entity.Description;
            project.Type = entity.Type;
            project.StartDate = entity.StartDate;
            project.EndDate = entity.EndDate;
            project.ProfessorId = entity.ProfessorId;

            if (entity.Skills is not null && entity.Skills.Any(x => x.SkillId != 0)) // Se a lista de habilidades não for vazia e houver habilidades
            {
                SkillsCRUD skillsCRUD = new(); // OBS: Verificar se o uso disso para acessar o "banco de dados" é correto//RESTful
                foreach (Skill skill in entity.Skills) // Para cada habilidade na lista de habilidades
                {
                    if (!project.Skills.Any(x => x.SkillId == skill.SkillId) && skill.SkillId != 0) // Se o projeto não possuir a habilidade e a habilidade não for nula
                    {
                        Skill? existingSkill = skillsCRUD.ReadById(skill.SkillId); // Verifica se a habilidade já existe no banco de dados
                        if (existingSkill is null) // Se a habilidade não existir no banco de dados
                        {
                            skillsCRUD.Create(skill); // Cria a habilidade
                            project.Skills.Add(skill); // Adiciona a habilidade ao projeto
                        }
                        else // Se a habilidade existir no banco de dados
                        {
                            project.Skills.Add(existingSkill); // Adiciona a habilidade ao projeto
                        }
                    }
                }
            }
        }
    }

    private Project? Find(string Title)
    {
        return Projects.FirstOrDefault(x => x.Title == Title);
    }

    private Project? Find(int id)
    {
        return Projects.FirstOrDefault(x => x.ProjectId == id);
    }
}
