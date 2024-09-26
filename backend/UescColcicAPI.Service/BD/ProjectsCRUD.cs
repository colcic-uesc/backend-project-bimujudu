
using UescColcicAPI.Services.BD.Interfaces;
using UescColcicAPI.Core;

namespace UescColcicAPI.Services.BD;

public class ProjectsCRUD : IProjectsCRUD
{
    private static readonly List<Project> Projects = new()
    {
        new Project { ProjectId = 1, Title = "IA na Educação", Description = "Projeto de IA aplicado a educação", Type = "Pesquisa", StartDate = DateTime.Now, EndDate = DateTime.Now.AddYears(1)},
        new Project { ProjectId = 2, Title = "Imagem e Ação", Description = "Pesquisa sobre processamento de imagens", Type = "Pesquisa", StartDate = DateTime.Now, EndDate = DateTime.Now.AddYears(1)},
        new Project { ProjectId = 3, Title = "Campeonato de Programação Universitário", Description = "Recrutamento para competições de programação", Type = "Projeto", StartDate = DateTime.Now, EndDate = DateTime.Now.AddYears(1)},
        new Project { ProjectId = 4, Title = "Monitoria de Programação", Description = "Monitoria nas disciplinas de Linguagem de Programação", Type = "Monitoria", StartDate = DateTime.Now, EndDate = DateTime.Now.AddYears(1)}
    };
    private readonly SkillsCRUD skillsCRUD = new();
    public void Create(Project entity)
    {
        var project = this.Find(entity.ProjectId);
        if (project is null)
        {
            Projects.Add(entity);
            var projectCreated = entity;

            // Verifica se o projeto tem habilidades para adicionar
            if (projectCreated.Skills is not null &&  projectCreated.Skills.Any(x => x.SkillId != 0)){
                for (int i = 0; i <  projectCreated.Skills.Count; i++){
                    Skill skill =  projectCreated.Skills[i];
                    
                    if (skill.SkillId != 0){
                        Skill? existingSkill = skillsCRUD.ReadById(skill.SkillId);

                        // Se a habilidade não existe no banco de dados, cria a habilidade
                        if (existingSkill is null){
                            skillsCRUD.Create(skill);
                        }
                        else{
                            // Substitui a habilidade existente no banco pela atual, isso garante integridade
                            projectCreated.Skills[i] = existingSkill;
                        }
                    }
                }
            }

        }
    }

    public void Delete(Project entity)
    {
        ProfessorsCRUD professorsCRUD = new();
        var professors = professorsCRUD.ReadAll();
        var project = this.Find(entity.ProjectId);
        
        if (project is not null){
            foreach(var professor in professors){
                if (professor.Projects != null && professor.Projects.Any(s => s.ProjectId == entity.ProjectId)){
                        // Remove o projeto da lista de professores
                        professor.Projects.RemoveAll(s => s.ProjectId == entity.ProjectId);
                }
            }
            Projects.Remove(project);
        }      
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

            if (entity.Skills is not null && entity.Skills.Any(x => x.SkillId != 0)) // Se a lista de habilidades não for vazia e houver habilidades
            {
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

    // Adiciona skill no projeto
    // A diferença entre o Update e AddSkillToProject é que os atributos de project não serão atualizados, apenas a lista de skills
    public void AddSkillToProject(int projectID, Skill[] entity){
        var project = this.Find(projectID);
        if (project is not null)
        {

            if (entity is not null && entity.Any(x => x.SkillId != 0)) // Se a lista de habilidades não for vazia e houver habilidades
            {
                
                foreach (Skill skill in entity) // Para cada habilidade na lista de habilidades
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
    // Exclui as skills que são passadas na lista de skills do projeto, de acordo com o id
    public void DeleteSkillToProject(int projectID, Skill[] entity){
        var project = this.Find(projectID);
        if (project is not null)
        {
            if (entity is not null && entity.Any(x => x.SkillId != 0)) // Se a lista de habilidades não for vazia e houver habilidades
            {
                
                foreach (Skill skill in entity) // Para cada habilidade na lista de habilidades
                {
                    if (skill.SkillId != 0) // habilidade não for nula
                    {
                        int index = project.Skills.FindIndex(x => x.SkillId == skill.SkillId); // Encontra o index da skill no projeto
                        if (index != -1) // Se a skill existir no projeto
                        {
                            project.Skills.RemoveAt(index);
                        }
                    }
                }
            }
        }
    }
}
