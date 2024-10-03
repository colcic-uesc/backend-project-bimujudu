using UescColcicAPI.Services.BD.Interfaces;
using UescColcicAPI.Core;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;

namespace UescColcicAPI.Services.BD;

public class StudentsCRUD : IStudentsCRUD
{
    private UescColcicDBContext _context;
   public StudentsCRUD(UescColcicDBContext context){
        _context = context;
   }
    public void Create(Student entity)
    {
        _context.Students.Add(entity);
        _context.SaveChanges();
    }

    public void Delete(Student entity)
    {   
        var student = this.Find(entity.StudentId);
        if(student is  not null){
            _context.Students.Remove(student);

            _context.SaveChanges();
        }
    }

    public IEnumerable<Student> ReadAll()
    {
        return _context.Students;
    }

    public Student? ReadById(int id)
    {
        var student = this.Find(id);
        return student;
    }

    public void Update(Student entity)
    {
        var student = this.Find(entity.StudentId);
        if(student is not null)
        {
            student.Registration = entity.Registration;
            student.Name = entity.Name;
            student.Email = entity.Email;
            student.Course = entity.Course;
            student.Bio = entity.Bio;
            _context.SaveChanges();
        }
    }

    public void AddSkillToStudent(int studentId, int skillId, int weight){
        var student = this.Find(studentId);
        var skill = _context.Skills.FirstOrDefault(x => x.SkillId == skillId);

        if(student is not null && skill is not null){
            var StudentSkill = new StudentSkill{
                StudentId = studentId,
                SkillId = skillId,
                Weight = weight,
                student = student,
                skill = skill
            };
            _context.StudentSkills.Add(StudentSkill);
            _context.SaveChanges();
        }
    }

    public void RemoveSkillToStudent(int studentId, int skillId){
        var studentSkill = _context.StudentSkills.FirstOrDefault(x => x.SkillId == skillId && x.StudentId == studentId);
        if(studentSkill is not null){
            _context.StudentSkills.Remove(studentSkill);
            _context.SaveChanges();
        }
    }

    public void UpdateSkillToStudent(int studentId, int skillId, int weight){
        var studentSkill = _context.StudentSkills.FirstOrDefault(x => x.SkillId == skillId && x.StudentId == studentId);
        if(studentSkill is not null){
            studentSkill.Weight = weight;
            _context.SaveChanges();
        }
    }

    public IEnumerable<Skill> ReadAllSkillsToStudent(int studentId){
        // Buscando o estudante pelo ID, incluindo suas habilidades
        var student = _context.Students
            .Include(s => s.StudentSkills) // Incluindo as associações
                .ThenInclude(ss => ss.skill) // Incluindo as habilidades associadas
            .FirstOrDefault(s => s.StudentId == studentId);

        // Retornando as habilidades do estudante, se ele existir
        if (student != null)
        {
            return student.StudentSkills.Select(ss => ss.skill).ToList();
        }

        return Enumerable.Empty<Skill>(); // Retorna uma lista vazia se o estudante não for encontrado
        
    }

    private Student? Find(string email)
    {
        return _context.Students.FirstOrDefault(x => x.Email == email);
    }

    private Student? Find(int id)
    {
        return _context.Students.FirstOrDefault(x => x.StudentId == id);
    }

    

}
