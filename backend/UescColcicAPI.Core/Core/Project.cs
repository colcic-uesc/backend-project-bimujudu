using System;
using System.Text.Json.Serialization;
using UescColcicAPI.Core;

public class Project
{
    public int ProjectId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Type { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }

    [JsonIgnore]
    public int? ProfessorId { get; set; } 
    [JsonIgnore]
    public virtual Professor? Professor { get; set; } 

    [JsonIgnore]
    public virtual ICollection<ProjectSkill> ProjectSkills { get; set; } = new List<ProjectSkill>();
}

