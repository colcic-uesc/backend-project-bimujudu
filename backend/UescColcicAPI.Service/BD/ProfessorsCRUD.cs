using UescColcicAPI.Services.BD.Interfaces;
using UescColcicAPI.Core;

namespace UescColcicAPI.Services.BD;

public class ProfessorsCRUD : IProfessorsCRUD
{
    private static readonly List<Professor> Professors = new()
    {
        new Professor { ProfessorId = 1, Name = "Helder", Email = "helder@uesc.br", Department = "Computação", Bio = "Especialista em Web." },
        new Professor { ProfessorId = 2, Name = "Otacilio", Email = "ota@uesc.br", Department = "Computação", Bio = "Especialista em Algoritmos." },
        new Professor { ProfessorId = 3, Name = "Hamilton", Email = "hamilton@uesc.br", Department = "Computação", Bio = "Especialista em Algoritmos." },
        new Professor { ProfessorId = 4, Name = "Vânia", Email = "vania@uesc.br", Department = "Computação", Bio = "Especialista em Computação Gráfica." }
    };
    private readonly ProjectsCRUD projectCRUD = new();
    public void Create(Professor entity)
    {
        var professor = this.Find(entity.ProfessorId);
        if (professor is null)
        {
            Professors.Add(entity);
            var professorCreated = entity;

            // Verifica se o projeto tem projeto para adicionar
            if (professorCreated.Projects is not null &&  professorCreated.Projects.Any(x => x.ProjectId != 0)){
                for (int i = 0; i <  professorCreated.Projects.Count; i++){
                    Project project =  professorCreated.Projects[i];
                    
                    if (project.ProjectId != 0){
                        Project? existingProject = projectCRUD.ReadById(project.ProjectId);

                        // Se o projeto não existe no banco de dados, cria o projeto
                        if (existingProject is null){
                            projectCRUD.Create(project);
                        }
                        else{
                            // Substitui o projeto existente no banco pela atual, isso garante integridade
                            professorCreated.Projects[i] = existingProject;
                        }
                    }
                }
            }

        }
    }

    public void Delete(Professor entity)
    {
        var professor = this.Find(entity.ProfessorId);
        if (professor is not null)
            Professors.Remove(professor);
    }

    public IEnumerable<Professor> ReadAll()
    {
        return Professors;
    }

    public Professor? ReadById(int id)
    {
        var professor = this.Find(id);
        return professor;
    }

    public void Update(Professor entity)
    {
        var professor = this.Find(entity.ProfessorId);
        if (professor is not null)
        {
            professor.Name = entity.Name;
            professor.Email = entity.Email;
            professor.Department = entity.Department;
            professor.Bio = entity.Bio;

            if (entity.Projects is not null && entity.Projects.Any(x => x.ProjectId != 0)) // Se a lista de projetos não for vazia e houver projeto
            {
                
                foreach (Project project in entity.Projects) // Para cada projeto na lista de projetos
                {
                    if (!professor.Projects.Any(x => x.ProjectId == project.ProjectId) && project.ProjectId != 0) // Se o professor não possuir o projeto e o projeto não for nulo
                    {
                        Project? existingProject = projectCRUD.ReadById(project.ProjectId); // Verifica se o projeto já existe no banco de dados
                        if (existingProject is null) // Se o projeto não existir no banco de dados
                        {
                            projectCRUD.Create(project); // Cria o projeto
                            professor.Projects.Add(project); // Adiciona o projeto ao professor
                        }
                        else // Se o projeto existir no banco de dados
                        {
                            professor.Projects.Add(existingProject); // Adiciona o projeto ao professor
                        }
                    }
                }
            }
        }
    }

    private Professor? Find(string Email)
    {
        return Professors.FirstOrDefault(x => x.Email == Email);
    }

    private Professor? Find(int id)
    {
        return Professors.FirstOrDefault(x => x.ProfessorId == id);
    }
    // Adiciona os projetos ao professor
    // A diferença entre o Update e AddProjectToProfessor é que os atributos de professor não serão atualizados, apenas a lista de projetos
    public void AddProjectToProfessor(int professorID, Project[] entity){
        var professor = this.Find(professorID);
        if (professor is not null)
        {

            if (entity is not null && entity.Any(x => x.ProjectId != 0)) // Se a lista de projetos não for vazia e houver projetos
            {
                
                foreach (Project project in entity) // Para cada projeto na lista de projetos
                {
                    if (!professor.Projects.Any(x => x.ProjectId == project.ProjectId) && project.ProjectId != 0) // Se o professor não possuir a projeto e o projeto não for nulo
                    {
                        Project? existingProject = projectCRUD.ReadById(project.ProjectId); // Verifica se o projeto já existe no banco de dados
                        if (existingProject is null) // Se o projeto não existir no banco de dados
                        {
                            projectCRUD.Create(project); // Cria o projeto
                            professor.Projects.Add(project); // Adiciona o projeto ao professsor
                        }
                        else // Se o projeto existir no banco de dados
                        {
                            professor.Projects.Add(existingProject); // Adiciona o projeto ao professsor
                        }
                    }
                }
            }
        }
    }
    // Exclui os projetos que são passadas na lista de projetos do professor, de acordo com o id
    public void DeleteProjectToProfessor(int professorID, Project[] entity){
        var professor = this.Find(professorID);
        if (professor is not null)
        {
            if (entity is not null && entity.Any(x => x.ProjectId != 0)) // Se a lista de projetos não for vazia e houver projetos
            {
                
                foreach (Project project in entity) // Para cada projeto na lista de projetos
                {
                    if (project.ProjectId != 0) // projeto não for nulo
                    {
                        int index = professor.Projects.FindIndex(x => x.ProjectId == project.ProjectId); // Encontra o index do projeto no professor
                        if (index != -1) // Se o projeto existir no professor
                        {
                            professor.Projects.RemoveAt(index);
                        }
                    }
                }
            }
        }
    }
}