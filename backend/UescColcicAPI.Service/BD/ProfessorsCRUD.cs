using UescColcicAPI.Services.BD.Interfaces;
using UescColcicAPI.Core;

namespace UescColcicAPI.Services.BD;

public class ProfessorsCRUD : IProfessorsCRUD
{
    private static readonly List<Professor> Professors = new()
    {
        new Professor { professorId = 1, name = "Helder", email = "helder@uesc.br", department = "Computação", bio = "Especialista em web" },
        new Professor { professorId = 2, name = "Otacilio", email = "ota@uesc.br", department = "Matemática", bio = "Especialista em Algoritmos" }
    };

    public void Create(Professor entity)
    {
        Professors.Add(entity);
    }

    public void Delete(Professor entity)
    {
        var professor = this.Find(entity.professorId);
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
        var professor = this.Find(entity.professorId);
        if (professor is not null)
        {
            professor.name = entity.name;
            professor.email = entity.email;
            professor.department = entity.department;
            professor.bio = entity.bio;
        }
    }

    private Professor? Find(string email)
    {
        return Professors.FirstOrDefault(x => x.email == email);
    }

    private Professor? Find(int id)
    {
        return Professors.FirstOrDefault(x => x.professorId == id);
    }
}