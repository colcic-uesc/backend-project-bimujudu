
using UescColcicAPI.Services.BD.Interfaces;
using UescColcicAPI.Core;

namespace UescColcicAPI.Services.BD;

public class ProjectsCRUD : IProjectsCRUD
{
    private static readonly List<Project> Projects = new()
    {
        new Project { projectId = 1, title = "IA na Educação", description = "Projeto de IA aplicado a educação", type = "Pesquisa", startDate = DateTime.Now, endDate = DateTime.Now.AddYears(1) },
        new Project { projectId = 2, title = "Imagem e Ação", description = "Pesquisa sobre processamento de imagens", type = "Pesquisa", startDate = DateTime.Now, endDate = DateTime.Now.AddYears(1) }
    };

    public void Create(Project entity)
    {
        Projects.Add(entity);
    }

    public void Delete(Project entity)
    {
        var project = this.Find(entity.projectId);
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
        var project = this.Find(entity.projectId);
        if (project is not null)
        {
            project.title = entity.title;
            project.description = entity.description;
            project.type = entity.type;
            project.startDate = entity.startDate;
            project.endDate = entity.endDate;
        }
    }

    private Project? Find(string title)
    {
        return Projects.FirstOrDefault(x => x.title == title);
    }

    private Project? Find(int id)
    {
        return Projects.FirstOrDefault(x => x.projectId == id);
    }
}
