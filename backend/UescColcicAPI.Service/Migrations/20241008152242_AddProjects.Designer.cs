﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UescColcicAPI.Services.BD;

#nullable disable

namespace UescColcicAPI.Services.Migrations
{
    [DbContext(typeof(UescColcicDBContext))]
    [Migration("20241008152242_AddProjects")]
    partial class AddProjects
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.8");

            modelBuilder.Entity("Project", b =>
                {
                    b.Property<int>("ProjectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("ProfessorId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("ProjectId");

                    b.HasIndex("ProfessorId");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("ProjectSkill", b =>
                {
                    b.Property<int>("ProjectId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SkillId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Weight")
                        .HasColumnType("INTEGER");

                    b.HasKey("ProjectId", "SkillId");

                    b.HasIndex("SkillId");

                    b.ToTable("ProjectSkills");
                });

            modelBuilder.Entity("StudentSkill", b =>
                {
                    b.Property<int>("StudentId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SkillId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Weight")
                        .HasColumnType("INTEGER");

                    b.HasKey("StudentId", "SkillId");

                    b.HasIndex("SkillId");

                    b.ToTable("StudentSkills");
                });

            modelBuilder.Entity("UescColcicAPI.Core.Professor", b =>
                {
                    b.Property<int>("ProfessorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Bio")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Department")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("ProfessorId");

                    b.ToTable("Professors");
                });

            modelBuilder.Entity("UescColcicAPI.Core.Skill", b =>
                {
                    b.Property<int>("SkillId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("SkillId");

                    b.ToTable("Skills");
                });

            modelBuilder.Entity("UescColcicAPI.Core.Student", b =>
                {
                    b.Property<int>("StudentId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Bio")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Course")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Registration")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("StudentId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("Project", b =>
                {
                    b.HasOne("UescColcicAPI.Core.Professor", "Professor")
                        .WithMany("Projects")
                        .HasForeignKey("ProfessorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Professor");
                });

            modelBuilder.Entity("ProjectSkill", b =>
                {
                    b.HasOne("Project", "project")
                        .WithMany("ProjectSkills")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UescColcicAPI.Core.Skill", "skill")
                        .WithMany("ProjectSkills")
                        .HasForeignKey("SkillId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("project");

                    b.Navigation("skill");
                });

            modelBuilder.Entity("StudentSkill", b =>
                {
                    b.HasOne("UescColcicAPI.Core.Skill", "skill")
                        .WithMany("StudentSkills")
                        .HasForeignKey("SkillId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UescColcicAPI.Core.Student", "student")
                        .WithMany("StudentSkills")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("skill");

                    b.Navigation("student");
                });

            modelBuilder.Entity("UescColcicAPI.Core.Student", b =>
                {
                    b.HasOne("UescColcicAPI.Core.Professor", "Professor")
                        .WithMany("Students")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Professor");
                });

            modelBuilder.Entity("Project", b =>
                {
                    b.Navigation("ProjectSkills");
                });

            modelBuilder.Entity("UescColcicAPI.Core.Professor", b =>
                {
                    b.Navigation("Projects");

                    b.Navigation("Students");
                });

            modelBuilder.Entity("UescColcicAPI.Core.Skill", b =>
                {
                    b.Navigation("ProjectSkills");

                    b.Navigation("StudentSkills");
                });

            modelBuilder.Entity("UescColcicAPI.Core.Student", b =>
                {
                    b.Navigation("StudentSkills");
                });
#pragma warning restore 612, 618
        }
    }
}
