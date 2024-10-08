using System;
using System.Text.Json.Serialization;

namespace UescColcicAPI.Core
{
    public class Professor
    {
        public int ProfessorId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Department { get; set; }
        public string Bio { get; set; }

        [JsonIgnore]
        public virtual ICollection<Student> Students { get; set; } = new List<Student>(); // Relacionamento com Students

        [JsonIgnore]
        public virtual ICollection<Project> Projects { get; set; } = new List<Project>(); // Relacionamento com Projects
    }
}
