using System;
using System.Collections.Generic;

namespace UescColcicAPI.Core;

public class Student
{
   public int studentId {get; set;}
   public string registration {get; set;}
   public string name {get; set;} 
   public string email {get; set;}
   public string course {get; set;}
   public string bio {get; set;}
   public List<Skill> skills { get; set; } = new List<Skill>();
}
