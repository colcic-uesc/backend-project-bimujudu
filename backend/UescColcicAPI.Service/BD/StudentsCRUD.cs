﻿using UescColcicAPI.Services.BD.Interfaces;
using UescColcicAPI.Core;

namespace UescColcicAPI.Services.BD;

public class StudentsCRUD : IStudentsCRUD
{
    private static readonly List<Student> Students = new()
   {
      new Student { studentId = 1, name = "Douglas", email = "douglas.cic@uesc.br" },
      new Student { studentId = 2, name = "Estevão", email = "estevao.cic@uesc.br" },
      new Student { studentId = 3, name = "Gabriel", email = "gabriel.cic@uesc.br" },
      new Student { studentId = 4, name = "Gabriela", email = "gabriela.cic@uesc.br" }
   };
    public void Create(Student entity)
    {
        Students.Add(entity);
    }

    public void Delete(Student entity)
    {   
        var student = this.Find(entity.studentId);
        if(student is  not null)
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
        var student = this.Find(entity.studentId);
        if(student is not null) student.name = entity.name;
    }

    private Student? Find(string email)
    {
        return Students.FirstOrDefault(x => x.email == email);
    }

    private Student? Find(int id)
    {
        return Students.FirstOrDefault(x => x.studentId == id);
    }

}