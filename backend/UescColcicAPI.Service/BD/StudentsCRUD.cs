﻿using UescColcicAPI.Services.BD.Interfaces;
using UescColcicAPI.Core;

namespace UescColcicAPI.Services.BD;

public class StudentsCRUD : IStudentsCRUD
{
    private static readonly List<Student> Students = new()
   {
      new Student { StudentId = 1, Registration = "202410000", Name = "Douglas", Email = "douglas.cic@uesc.br", Course = "Ciência da Computação", Bio = "Estudante de Ciência da Computação na UESC" },
      new Student { StudentId = 2, Registration = "202410001", Name = "Estevão", Email = "estevao.cic@uesc.br", Course = "Ciência da Computação", Bio = "Estudante de Ciência da Computação na UESC" },
      new Student { StudentId = 3, Registration = "202410002", Name = "Gabriel", Email = "gabriel.cic@uesc.br", Course = "Ciência da Computação", Bio = "Estudante de Ciência da Computação na UESC" },
      new Student { StudentId = 4, Registration = "202410003", Name = "Gabriela", Email = "gabriela.cic@uesc.br", Course = "Ciência da Computação", Bio = "Estudante de Ciência da Computação na UESC" }
   };
    public void Create(Student entity)
    {
        Students.Add(entity);
    }

    public void Delete(Student entity)
    {
        var student = this.Find(entity.StudentId);
        if (student is not null)
            Students.Remove(student);
    }

    public IEnumerable<Student> ReadAll()
    {
        return Students;
    }

    public Student? ReadById(int id)
    {
        var student = this.Find(id);
        return student;
    }

    public void Update(Student entity)
    {
        var student = this.Find(entity.StudentId);
        if (student is not null)
        {
            student.Name = entity.Name;
            student.Email = entity.Email;

            if (entity.Skills is not null && entity.Skills.Any(x => x.SkillId != 0)) // Se a lista de habilidades não for vazia e houver habilidades
            {
                SkillsCRUD skillsCRUD = new(); // OBS: Verificar se o uso disso para acessar o "banco de dados" é correto//RESTful
                foreach (Skill skill in entity.Skills) // Para cada habilidade na lista de habilidades
                {
                    if (!student.Skills.Any(x => x.SkillId == skill.SkillId) && skill.SkillId != 0) // Se o estudante não possuir a habilidade e a habilidade não for nula
                    {
                        Skill? existingSkill = skillsCRUD.ReadById(skill.SkillId); // Verifica se a habilidade já existe no banco de dados
                        if (existingSkill is null) // Se a habilidade não existir no banco de dados
                        {
                            skillsCRUD.Create(skill); // Cria a habilidade
                            student.Skills.Add(skill); // Adiciona a habilidade ao estudante
                        }
                        else // Se a habilidade existir no banco de dados
                        {
                            student.Skills.Add(existingSkill); // Adiciona a habilidade ao estudante
                        }
                    }
                }
            }
        }
    }

    private Student? Find(string Email)
    {
        return Students.FirstOrDefault(x => x.Email == Email);
    }

    private Student? Find(int id)
    {
        return Students.FirstOrDefault(x => x.StudentId == id);
    }

}