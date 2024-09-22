using System;
using System.Collections.Generic;

namespace UescColcicAPI.Core;

public class Student
{
   public int StudentId {get; set;}
   public string Registration {get; set;}
   public string Name {get; set;} 
   public string Email {get; set;}
   public string Course {get; set;}
   public string Bio {get; set;}
   public List<Skill> Skills { get; set; } = new List<Skill>();
}
