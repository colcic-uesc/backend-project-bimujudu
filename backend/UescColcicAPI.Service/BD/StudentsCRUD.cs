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
    private readonly SkillsCRUD skillsCRUD = new(); 
    public void Create(Student entity){
        var student = this.Find(entity.StudentId);
        if (student is null)
        {
            Students.Add(entity);
            var studentCreated = entity;

            // Verifica se o estudante tem habilidades para adicionar
            if (studentCreated.Skills is not null && studentCreated.Skills.Any(x => x.SkillId != 0)){
                for (int i = 0; i < studentCreated.Skills.Count; i++){
                    Skill skill = studentCreated.Skills[i];
                    
                    if (skill.SkillId != 0){
                        Skill? existingSkill = skillsCRUD.ReadById(skill.SkillId);

                        // Se a habilidade não existe no banco de dados, cria a habilidade
                        if (existingSkill is null){
                            skillsCRUD.Create(skill);
                        }
                        else{
                            // Substitui a habilidade existente no banco pela atual, isso garante integridade
                            studentCreated.Skills[i] = existingSkill;
                        }
                    }
                }
            }

        }
    }


    public void Delete(Student entity)
    {
        var student = this.Find(entity.StudentId);
        if (student is not null){
            Students.Remove(student);  
        }
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
            student.Registration = entity.Registration;
            student.Email = entity.Email;
            student.Course = entity.Course;
            student.Bio = entity.Bio;

            if (entity.Skills is not null && entity.Skills.Any(x => x.SkillId != 0)) // Se a lista de habilidades não for vazia e houver habilidades
            {
                
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

    // Adiciona as skills no estudante
    // A diferença entre o Update e AddSkillToStudent é que os atributos de studant não serão atualizados, apenas a lista de skills
    public void AddSkillToStudent(int studentID, Skill[] entity){
        var student = this.Find(studentID);
        if (student is not null)
        {

            if (entity is not null && entity.Any(x => x.SkillId != 0)) // Se a lista de habilidades não for vazia e houver habilidades
            {
                
                foreach (Skill skill in entity) // Para cada habilidade na lista de habilidades
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
    // Exclui as skills que são passadas na lista de skills do estudante, de acordo com o id
    public void DeleteSkillToStudent(int studentID, Skill[] entity){
        var student = this.Find(studentID);
        if (student is not null)
        {
            if (entity is not null && entity.Any(x => x.SkillId != 0)) // Se a lista de habilidades não for vazia e houver habilidades
            {
                
                foreach (Skill skill in entity) // Para cada habilidade na lista de habilidades
                {
                    if (skill.SkillId != 0) // habilidade não for nula
                    {
                        int index = student.Skills.FindIndex(x => x.SkillId == skill.SkillId); // Encontra o index da skill no estudante
                        if (index != -1) // Se a skill existir no estudante
                        {
                            student.Skills.RemoveAt(index);
                        }
                    }
                }
            }
        }
    }

}