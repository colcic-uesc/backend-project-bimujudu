using System;
using UescColcicAPI.Core;

namespace UescColcicAPI.Services.BD.Interfaces
{
    public interface IProfessorCRUD : IBaseCRUD<Professor>
    {
        public bool AddStudentToProfessor(int professorId, int studentId);
        public bool RemoveStudentFromProfessor(int professorId, int studentId);
        
        // Lê todos os estudantes que são mentorados por um professor
        public IEnumerable<Student> ReadAllStudentsOfProfessor(int professorId);

        public bool AddProjectToProfessor(int professorId, int projectId);
        public bool RemoveProjectFromProfessor(int professorId, int projectId);
        // Lê todos os projetos supervisionados por um professor
        public IEnumerable<Project> ReadAllProjectsOfProfessor(int professorId);
    }
}
