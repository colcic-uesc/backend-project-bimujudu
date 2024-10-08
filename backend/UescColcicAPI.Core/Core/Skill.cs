using System;
using System.Text.Json.Serialization;


namespace UescColcicAPI.Core;

public class Skill
{
      public int SkillId { get; set; }
      public string Title { get; set; }
      public string Description { get; set; }

      [JsonIgnore]
      public virtual ICollection<StudentSkill> StudentSkills { get; set; } = new List<StudentSkill>();

      [JsonIgnore]
      public virtual ICollection<ProjectSkill> ProjectSkills { get; set; } = new List<ProjectSkill>();
}

