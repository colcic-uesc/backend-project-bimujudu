using UescColcicAPI.Services.BD.Interfaces;
using UescColcicAPI.Core;
using Microsoft.EntityFrameworkCore;

namespace UescColcicAPI.Services.BD;

public class ProfessorCRUD : IProfessorCRUD
{
    private UescColcicDBContext _context;

    public ProfessorCRUD(UescColcicDBContext context)
    {
        _context = context;
    }

    // Implementação dos métodos CRUD básicos

    public void Create(Professor entity)
    {
        _context.Professors.Add(entity);
        _context.SaveChanges();
    }

    public void Delete(Professor entity)
    {
        var professor = this.Find(entity.ProfessorId);
        if (professor is not null)
        {
            _context.Professors.Remove(professor);
            _context.SaveChanges();
        }
    }

    public IEnumerable<Professor> ReadAll()
    {
        return _context.Professors
            .Include(p => p.Students) // Inclui os alunos associados
            .Include(p => p.Projects); // Inclui os projetos associados
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
            _context.SaveChanges();
        }
    }

    // Implementação dos métodos específicos da interface IProfessorCRUD

    public void AddStudentToProfessor(int professorId, int studentId)
    {
        var professor = this.Find(professorId);
        var student = _context.Students.FirstOrDefault(s => s.StudentId == studentId);

        if (professor is not null && student is not null)
        {
            professor.Students.Add(student);
            _context.SaveChanges();
        }
    }

    public void RemoveStudentFromProfessor(int professorId, int studentId)
    {
        var professor = this.Find(professorId);
        if (professor is not null)
        {
            var student = professor.Students.FirstOrDefault(s => s.StudentId == studentId);
            if (student is not null)
            {
                professor.Students.Remove(student);
                _context.SaveChanges();
            }
        }
    }

    public IEnumerable<Student> ReadAllStudentsOfProfessor(int professorId)
    {
        var professor = this.Find(professorId);
        return professor?.Students ?? Enumerable.Empty<Student>();
    }

    public void AddProjectToProfessor(int professorId, int projectId)
    {
        var professor = this.Find(professorId);
        var project = _context.Projects.FirstOrDefault(p => p.ProjectId == projectId);

        if (professor is not null && project is not null)
        {
            professor.Projects.Add(project);
            _context.SaveChanges();
        }
    }

    public void RemoveProjectFromProfessor(int professorId, int projectId)
    {
        var professor = this.Find(professorId);
        if (professor is not null)
        {
            var project = professor.Projects.FirstOrDefault(p => p.ProjectId == projectId);
            if (project is not null)
            {
                professor.Projects.Remove(project);
                _context.SaveChanges();
            }
        }
    }

    public IEnumerable<Project> ReadAllProjectsOfProfessor(int professorId)
    {
        var professor = this.Find(professorId);
        return professor?.Projects ?? Enumerable.Empty<Project>();
    }

    // Método auxiliar privado para buscar o professor pelo ID
    private Professor? Find(int id)
    {
        return _context.Professors
            .Include(p => p.Students) // Inclui os alunos associados
            .Include(p => p.Projects) // Inclui os projetos associados
            .FirstOrDefault(p => p.ProfessorId == id);
    }
}
