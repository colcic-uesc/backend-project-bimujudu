using System;
using UescColcicAPI.Core;

namespace UescColcicAPI.Services.BD.Interfaces;

public interface IProfessorsCRUD : IBaseCRUD<Professor>
{
    public void AddProjectToProfessor(int professorID, Project[] entity);
    public void DeleteProjectToProfessor(int professorID, Project[] entity);
}
