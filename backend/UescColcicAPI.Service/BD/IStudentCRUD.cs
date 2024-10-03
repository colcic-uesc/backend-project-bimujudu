using System;
using UescColcicAPI.Core;

namespace UescColcicAPI.Services.BD.Interfaces;

public interface IStudentsCRUD : IBaseCRUD<Student>
{
      public void AddSkillToStudent(int StudentId, int SkillId, int weight);
      public void RemoveSkillToStudent(int studentId, int skillId);
      public void UpdateSkillToStudent(int studentId, int skillId, int weight);
      public IEnumerable<Skill> ReadAllSkillsToStudent(int studentId);
}
