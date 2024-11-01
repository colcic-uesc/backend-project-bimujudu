using System;
using UescColcicAPI.Core;

namespace UescColcicAPI.Services.BD.Interfaces;

public interface IUsersCRUD : IBaseCRUD<User>
{
    public bool AddProfessorToUser(int professorId, int userId);
    public bool RemoveProfessorFromUser(int professorId, int userid);
    public IEnumerable<Professor> ReadAllProfessorsOfUser(int userId);
    public bool AddStudentToUser(int studentId, int userId);
    public bool RemoveStudentToUser(int studentId, int userid);
    public IEnumerable<Student> ReadAllStudentsOfUser(int userId);
}
