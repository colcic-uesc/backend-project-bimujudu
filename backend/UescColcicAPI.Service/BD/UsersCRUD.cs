using UescColcicAPI.Services.BD.Interfaces;
using UescColcicAPI.Core;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;

namespace UescColcicAPI.Services.BD;

public class UsersCRUD : IUsersCRUD
{
    private UescColcicDBContext _context;
   public UsersCRUD(UescColcicDBContext context){
        _context = context;
   }
    public void Create(User entity)
    {
        _context.Users.Add(entity);
        _context.SaveChanges();
    }

    public void Delete(User entity)
    {   
        var user = this.Find(entity.UserId);
        if(user is not null){
            _context.Users.Remove(user);
            _context.SaveChanges();
        }
    }

    public IEnumerable<User> ReadAll()
    {
        return _context.Users.Include(s => s.Students).Include(p => p.Professors);
    }

    public User? ReadById(int id)
    {
        var user = this.Find(id);
        return user;
    }

    public void Update(User entity)
    {
        var user = this.Find(entity.UserId);
        if(user is not null)
        {
            user.UserName = entity.UserName;
            user.Password = entity.Password;
            _context.SaveChanges();
        }
    }

    private User? Find(int id)
    {
        return _context.Users.Include(s => s.Students).Include(p => p.Professors).FirstOrDefault(x => x.UserId == id);
    }

    // Users -> professors
    public bool AddProfessorToUser(int professorId, int userId)
    {
        var user = this.Find(userId);
        var professor = _context.Professors.FirstOrDefault(s => s.ProfessorId == professorId);

        if (professor is not null && user is not null)
        {
            user.Professors.Add(professor);
            _context.SaveChanges();
            return true;
        }

        return false;
    }

    public bool RemoveProfessorFromUser(int professorId, int userid)
    {
        var user = this.Find(userid);
        if (user is not null)
        {
            var professor = user.Professors.FirstOrDefault(s => s.ProfessorId == professorId);
            if (professor is not null)
            {
                user.Professors.Remove(professor);
                _context.SaveChanges();
                return true;
            }
        }

        return false;
    }


    public IEnumerable<Professor> ReadAllProfessorsOfUser(int userId)
    {
        var user = this.Find(userId);
        return user?.Professors ?? Enumerable.Empty<Professor>();
    }

    // Users -> Students
    public bool AddStudentToUser(int studentId, int userId)
    {
        var user = this.Find(userId);
        var student = _context.Students.FirstOrDefault(s => s.StudentId == studentId);

        if (student is not null && user is not null)
        {
            user.Students.Add(student);
            _context.SaveChanges();
            return true;
        }

        return false;
    }

    public bool RemoveStudentToUser(int studentId, int userid)
    {
        var user = this.Find(userid);
        if (user is not null)
        {
            var student = user.Students.FirstOrDefault(s => s.StudentId == studentId);
            if (student is not null)
            {
                user.Students.Remove(student);
                _context.SaveChanges();
                return true;
            }
        }

        return false;
    }


    public IEnumerable<Student> ReadAllStudentsOfUser(int userId)
    {
        var user = this.Find(userId);
        return user?.Students ?? Enumerable.Empty<Student>();
    }

}
