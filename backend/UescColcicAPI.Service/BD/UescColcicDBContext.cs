using System;
using Microsoft.EntityFrameworkCore;
using UescColcicAPI.Core;

namespace UescColcicAPI.Services.BD;

public class UescColcicDBContext : DbContext
{
   public DbSet<Student> Students { get; set; }
   public DbSet<Skill> Skills { get; set; }
   public DbSet<StudentSkill> StudentSkills { get; set; }

   public DbSet<Professor> Professors { get; set; }
   public DbSet<Project> Projects { get; set; }
   public DbSet<ProjectSkill> ProjectSkills { get; set; }

   protected override void OnModelCreating(ModelBuilder modelBuilder)
   {
        modelBuilder.Entity<Skill>().HasKey(x => x.SkillId);
        modelBuilder.Entity<Student>().HasKey(x => x.StudentId);
        // Chave primaria composta 
        modelBuilder.Entity<StudentSkill>().HasKey(x => new { x.StudentId, x.SkillId});

        modelBuilder.Entity<Professor>().HasKey(x => x.ProfessorId);
        modelBuilder.Entity<Project>().HasKey(x => x.ProjectId);
        // Chave primaria composta 
        modelBuilder.Entity<ProjectSkill>().HasKey(x => new { x.ProjectId, x.SkillId});

        // Relacionamento student -> studentSkill
        modelBuilder.Entity<StudentSkill>()
            .HasOne(x => x.student)
            .WithMany(X => X.StudentSkills)
            .HasForeignKey(x => x.StudentId);

        // Relacionamento skill -> StudentSkill
        modelBuilder.Entity<StudentSkill>()
            .HasOne(x => x.skill)
            .WithMany(x => x.StudentSkills)
            .HasForeignKey(x => x.SkillId);

        // Relacionamento project -> ProjectSkill
        modelBuilder.Entity<ProjectSkill>()
            .HasOne(x => x.project)
            .WithMany(X => X.ProjectSkills)
            .HasForeignKey(x => x.ProjectId);

        // Relacionamento skill -> ProjectSkill
        modelBuilder.Entity<ProjectSkill>()
            .HasOne(x => x.skill)
            .WithMany(x => x.ProjectSkills)
            .HasForeignKey(x => x.SkillId);

        // Relacionamento professor -> student
        modelBuilder.Entity<Student>()
            .HasOne(x => x.Professor)
            .WithMany(X => X.Students)
            .HasForeignKey(x => x.ProfessorId)
            .OnDelete(DeleteBehavior.SetNull); 

        // Relacionamento professor -> project
        modelBuilder.Entity<Project>()
            .HasOne(x => x.Professor)
            .WithMany(X => X.Projects)
            .HasForeignKey(x => x.ProfessorId);     

   }

   protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
   {
       optionsBuilder.UseSqlite("Data Source=..\\..\\backend\\UescColcicAPI\\UescColcicAPI.db");
   }
}
