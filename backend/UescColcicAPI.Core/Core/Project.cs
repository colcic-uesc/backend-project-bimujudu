using System;
using System.Collections.Generic;

namespace UescColcicAPI.Core;

public class Project
{
    public int ProjectId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Type { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }

    public List<Skill> Skills { get; set; } = new List<Skill>();

    public int ProfessorId { get; set; }

}

