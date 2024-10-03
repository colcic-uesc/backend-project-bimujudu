using System;
using Microsoft.EntityFrameworkCore;
using UescColcicAPI.Core;

namespace UescColcicAPI.Services.BD;

public class UescColcicDBContext : DbContext
{
   public DbSet<Student> Students { get; set; }
   public DbSet<Skill> Skills { get; set; }
   public DbSet<StudentSkill> StudentSkills { get; set; }

   protected override void OnModelCreating(ModelBuilder modelBuilder)
   {
        modelBuilder.Entity<Skill>().HasKey(x => x.SkillId);
        modelBuilder.Entity<Student>().HasKey(x => x.StudentId);
        // Chave primaria composta 
        modelBuilder.Entity<StudentSkill>().HasKey(x => new { x.StudentId, x.SkillId});

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


   }

   protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
   {
       optionsBuilder.UseSqlite("Data Source=..\\..\\backend\\UescColcicAPI\\UescColcicAPI.db");
   }
}
