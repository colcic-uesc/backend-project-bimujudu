using System;
using UescColcicAPI.Core;

namespace UescColcicAPI.Services.BD.Interfaces;

public interface IProjectsCRUD : IBaseCRUD<Project>
{
    public void AddSkillToProject(int projectID, Skill[] entity);
    public void DeleteSkillToProject(int projectID, Skill[] entity);
}
