using System;
using UescColcicAPI.Core;

namespace UescColcicAPI.Services.BD.Interfaces
{
    public interface IProjectCRUD : IBaseCRUD<Project>
    {
        bool AddSkillToProject(int projectId, int skillId, int weight);
        bool RemoveSkillFromProject(int projectId, int skillId);
        bool UpdateSkillInProject(int projectId, int skillId, int weight);
        IEnumerable<Skill> ReadAllSkillsInProject(int projectId);
    }
}
