using System.Collections.Generic;
using System.Linq;
using UescColcicAPI.Core;
using UescColcicAPI.Services.BD.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace UescColcicAPI.Services.BD
{
    public class ProjectCRUD : IProjectCRUD
    {
        private readonly UescColcicDBContext _context;

        public ProjectCRUD(UescColcicDBContext context)
        {
            _context = context;
        }

        public void Create(Project entity)
        {   
            _context.Projects.Add(entity);
            _context.SaveChanges();
        
        }

        public void Delete(Project entity)
        {
            var project = this.Find(entity.ProjectId);
            if (project is not null)
            {
                _context.Projects.Remove(project);
                _context.SaveChanges();
            }
        }

        public IEnumerable<Project> ReadAll()
        {
            return _context.Projects.Include(p => p.Professor).Include(p => p.ProjectSkills);
        }

        public Project? ReadById(int id)
        {
            return this.Find(id);
        }

        public void Update(Project entity)
        {
            var project = this.Find(entity.ProjectId);
            if (project is not null)
            {
                project.Title = entity.Title;
                project.Description = entity.Description;
                project.Type = entity.Type;
                project.StartDate = entity.StartDate;
                project.EndDate = entity.EndDate;
                _context.SaveChanges();
            }
        }

        public void AddSkillToProject(int projectId, int skillId, int weight)
        {
            var project = this.Find(projectId);
            var skill = _context.Skills.FirstOrDefault(x => x.SkillId == skillId);

            if (project is not null && skill is not null)
            {
                var projectSkill = new ProjectSkill
                {
                    ProjectId = projectId,
                    SkillId = skillId,
                    Weight = weight,
                    project = project,
                    skill = skill
                };
                _context.ProjectSkills.Add(projectSkill);
                _context.SaveChanges();
            }
        }

        public void RemoveSkillFromProject(int projectId, int skillId)
        {
            var projectSkill = _context.ProjectSkills
                .FirstOrDefault(x => x.ProjectId == projectId && x.SkillId == skillId);

            if (projectSkill is not null)
            {
                _context.ProjectSkills.Remove(projectSkill);
                _context.SaveChanges();
            }
        }

        public void UpdateSkillInProject(int projectId, int skillId, int weight)
        {
            var projectSkill = _context.ProjectSkills
                .FirstOrDefault(x => x.ProjectId == projectId && x.SkillId == skillId);

            if (projectSkill is not null)
            {
                projectSkill.Weight = weight;
                _context.SaveChanges();
            }
        }

        public IEnumerable<Skill> ReadAllSkillsInProject(int projectId)
        {
            var project = _context.Projects
                .Include(p => p.ProjectSkills) // Inclui as associações
                    .ThenInclude(ps => ps.skill) // Inclui as habilidades associadas
                .FirstOrDefault(p => p.ProjectId == projectId);

            // Retornando as habilidades do projeto, se ele existir
            if (project != null)
            {
                return project.ProjectSkills.Select(ps => ps.skill).ToList();
            }

            return Enumerable.Empty<Skill>(); // Retorna uma lista vazia se o projeto não for encontrado
        }

        private Project? Find(int id)
        {
            return _context.Projects
                .Include(p => p.ProjectSkills) // Inclui as habilidades do projeto
                .ThenInclude(ps => ps.skill) // Inclui as habilidades
                .FirstOrDefault(x => x.ProjectId == id);
        }
    }
}
