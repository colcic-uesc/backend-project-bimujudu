using UescColcicAPI.Core;
using System.Text.Json.Serialization;

public class User
{
    public int UserId {get; set;}
    
    public string UserName {get; set;}
    public string Password {get; set;}
    public string Rules {get; set;}

    [JsonIgnore]
    public virtual ICollection<Student> Students { get; set; } = new List<Student>();

    [JsonIgnore]
    public virtual ICollection<Professor> Professors { get; set; } = new List<Professor>();
}