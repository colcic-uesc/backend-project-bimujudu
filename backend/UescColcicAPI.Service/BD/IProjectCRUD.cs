using System;
using UescColcicAPI.Core;

namespace UescColcicAPI.Services.BD.Interfaces
{
    public interface IProjectCRUD : IBaseCRUD<Project>
    {
        void AddSkillToProject(int projectId, int skillId, int weight);
        void RemoveSkillFromProject(int projectId, int skillId);
        void UpdateSkillInProject(int projectId, int skillId, int weight);
        IEnumerable<Skill> ReadAllSkillsInProject(int projectId);
    }
}
