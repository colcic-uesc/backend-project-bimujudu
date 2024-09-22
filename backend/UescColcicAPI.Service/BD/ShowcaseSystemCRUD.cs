﻿using UescColcicAPI.Services.BD.Interfaces;
using UescColcicAPI.Core;

namespace UescColcicAPI.Services.BD;

public class ShowcaseSystemCRUD
{
    private List<Professor> Professores = new List<Professor>();
    private List<Student> Students = new List<Student>();
    private List<Project> Projects = new List<Project>();
    private List<Skill> Skills = new List<Skill>();

    // CREATE
    public void AddProfessor(Professor professor)
    {
        Professores.Add(professor);
    }

    public void AddStudent(Student student)
    {
        Students.Add(student);
    }

    public void AddProject(Project project)
    {
        Projects.Add(project);
    }

    public void AddSkill(Skill skill)
    {
        Skills.Add(skill);
    }

    // READ
    public Professor GetProfessor(int id)
    {
        return Professores.FirstOrDefault(p => p.ProfessorId == id);
    }

    public Student GetStudent(int id)
    {
        return Students.FirstOrDefault(s => s.StudentId == id);
    }

    public Project GetProject(int id)
    {
        return Projects.FirstOrDefault(p => p.ProjectId == id);
    }

    public Skill GetSkill(int id)
    {
        return Skills.FirstOrDefault(s => s.SkillId == id);
    }

    // UPDATE
    public void UpdateProfessor(Professor professor)
    {
        var existing = GetProfessor(professor.ProfessorId);
        if (existing != null)
        {
            existing.Name = professor.Name;
            existing.Email = professor.Email;
            existing.Department = professor.Department;
            existing.Bio = professor.Bio;
        }
    }

    public void UpdateStudent(Student student)
    {
        var existing = GetStudent(student.StudentId);
        if (existing != null)
        {
            existing.Name = student.Name;
            existing.Email = student.Email;
            existing.Course = student.Course;
            existing.Bio = student.Bio;
        }
    }

    public void UpdateProject(Project project)
    {
        var existing = GetProject(project.ProjectId);
        if (existing != null)
        {
            existing.Title = project.Title;
            existing.Description = project.Description;
            existing.Type = project.Type;
            existing.StartDate = project.StartDate;
            existing.EndDate = project.EndDate;
        }
    }

    public void UpdateSkill(Skill skill)
    {
        var existing = GetSkill(skill.SkillId);
        if (existing != null)
        {
            existing.Title = skill.Title;
            existing.Description = skill.Description;
        }
    }

    // DELETE
    public void DeleteProfessor(int id)
    {
        var professor = GetProfessor(id);
        if (professor != null)
        {
            Professores.Remove(professor);
        }
    }

    public void DeleteStudent(int id)
    {
        var student = GetStudent(id);
        if (student != null)
        {
            Students.Remove(student);
        }
    }

    public void DeleteProject(int id)
    {
        var project = GetProject(id);
        if (project != null)
        {
            Projects.Remove(project);
        }
    }

    public void DeleteSkill(int id)
    {
        var skill = GetSkill(id);
        if (skill != null)
        {
            Skills.Remove(skill);
        }
    }
}