using System;
using System.Collections.Generic;

namespace UescColcicAPI.Core;

 public class Project
    {
        public int projectId { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string type { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }

        public List<Skill> skills { get; set; } = new List<Skill>();

        public List<Professor> professors { get; set; } = new List<Professor>();
    }

