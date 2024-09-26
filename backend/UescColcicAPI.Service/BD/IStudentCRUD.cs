using System;
using UescColcicAPI.Core;

namespace UescColcicAPI.Services.BD.Interfaces;

public interface IStudentsCRUD : IBaseCRUD<Student>
{
    public void AddSkillToStudent(int studentID, Skill[] entity);
    public void DeleteSkillToStudent(int studentID, Skill[] entity);
}
