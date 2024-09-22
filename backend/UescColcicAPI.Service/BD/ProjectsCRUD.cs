
using UescColcicAPI.Services.BD.Interfaces;
using UescColcicAPI.Core;

namespace UescColcicAPI.Services.BD;

public class ProjectsCRUD : IProjectsCRUD
{
    private static readonly List<Project> Projects = new()
    {
        new Project { ProjectId = 1, Title = "IA na Educação", Description = "Projeto de IA aplicado a educação", Type = "Pesquisa", StartDate = DateTime.Now, EndDate = DateTime.Now.AddYears(1) },
        new Project { ProjectId = 2, Title = "Imagem e Ação", Description = "Pesquisa sobre processamento de imagens", Type = "Pesquisa", StartDate = DateTime.Now, EndDate = DateTime.Now.AddYears(1) },
        new Project { ProjectId = 3, Title = "Campeonato de Programação Universitário", Description = "Recrutamento para competições de programação", Type = "Projeto", StartDate = DateTime.Now, EndDate = DateTime.Now.AddYears(1) },
        new Project { ProjectId = 4, Title = "Monitoria de Programação", Description = "Monitoria nas disciplinas de Linguagem de Programação", Type = "Monitoria", StartDate = DateTime.Now, EndDate = DateTime.Now.AddYears(1) }
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
