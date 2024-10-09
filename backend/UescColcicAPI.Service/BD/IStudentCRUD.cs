using System;
using UescColcicAPI.Core;

namespace UescColcicAPI.Services.BD.Interfaces;

public interface IStudentsCRUD : IBaseCRUD<Student>
{
      public bool AddSkillToStudent(int StudentId, int SkillId, int weight);
      public bool RemoveSkillToStudent(int studentId, int skillId);
      public bool UpdateSkillToStudent(int studentId, int skillId, int weight);
      public IEnumerable<Skill> ReadAllSkillsToStudent(int studentId);
}
