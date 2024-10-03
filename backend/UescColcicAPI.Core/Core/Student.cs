using System;
using System.Text.Json.Serialization;

namespace UescColcicAPI.Core;

public class Student
{
   public int StudentId { get; set; }
   public string Registration { get; set; }
   public string Name { get; set; } 
   public string Email { get; set; }
   public string Course { get; set; }
   public string Bio { get; set; }
   [JsonIgnore]
   public virtual ICollection<StudentSkill> StudentSkills { get; set; } = new List<StudentSkill>();
}
