using System;
using UescColcicAPI.Core;

namespace UescColcicAPI.Services.BD.Interfaces
{
    public interface IProfessorCRUD : IBaseCRUD<Professor>
    {
        public void AddStudentToProfessor(int professorId, int studentId);
        public void RemoveStudentFromProfessor(int professorId, int studentId);
        
        // Lê todos os estudantes que são mentorados por um professor
        public IEnumerable<Student> ReadAllStudentsOfProfessor(int professorId);

        public void AddProjectToProfessor(int professorId, int projectId);
        public void RemoveProjectFromProfessor(int professorId, int projectId);
        // Lê todos os projetos supervisionados por um professor
        public IEnumerable<Project> ReadAllProjectsOfProfessor(int professorId);
    }
}
