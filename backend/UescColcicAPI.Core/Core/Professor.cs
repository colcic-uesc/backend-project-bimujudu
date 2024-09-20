using System;
using System.Collections.Generic;

namespace UescColcicAPI.Core;

public class Professor{
        public int professorId { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string department { get; set; }
        public string bio { get; set; }

        public List<Project> Projects { get; set; } = new List<Project>();
}