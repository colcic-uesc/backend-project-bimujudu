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

    public void Create(Professor entity)
    {
        Professors.Add(entity);
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
}