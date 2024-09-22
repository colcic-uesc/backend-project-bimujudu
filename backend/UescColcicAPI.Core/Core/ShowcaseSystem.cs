using System;
using System.Collections.Generic;

namespace UescColcicAPI.Core;

public class ShowcaseSystem
{
   public Student[] Students { get; set; }
   public Professor[] Professors { get; set; }
   public List<Skill> Skills { get; set; } = new List<Skill>();
   public Project[] Projects { get; set; }
}
