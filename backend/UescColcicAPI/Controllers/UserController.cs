using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UescColcicAPI.Services.BD.Interfaces;
using UescColcicAPI.Core;
using Microsoft.AspNetCore.Authorization;
namespace UescColcicAPI.Controllers


{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUsersCRUD _usersCRUD;

        public UsersController(IUsersCRUD usersCRUD)
        {
            _usersCRUD = usersCRUD;
        }

        [HttpPost(Name = "CreateUser")]
        public IActionResult Post([FromBody] User user)
        {
            if (user == null)
            {
                return BadRequest();
            }

            _usersCRUD.Create(user);

            return CreatedAtAction(nameof(Get), new { id = user.UserId }, user);
        }

        [HttpGet(Name = "GetUsers")]
        [Authorize]
        public IEnumerable<User> Get()
        {
            return _usersCRUD.ReadAll();
        }

        [HttpGet("{id}", Name = "GetUser")]
        [Authorize]
        public ActionResult<User> Get(int id)
        {
            try
            {
                var user = _usersCRUD.ReadById(id);
                if (user == null)
                {
                    return NotFound($"User with ID {id} not found.");
                }
                return Ok(user);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut(Name = "UpdateUser")]
        [Authorize]
        public IActionResult Update([FromBody] User user)
        {
            if (user == null)
            {
                return BadRequest();
            }

            _usersCRUD.Update(user);
            return Ok();
        }

        [HttpDelete(Name = "DeleteUser")]
        [Authorize]
        public IActionResult Delete([FromBody] User user)
        {
            if (user == null)
            {
                return BadRequest();
            }

            _usersCRUD.Delete(user);
            return Ok();
        }

        // Adiciona um professor ao user
        [HttpPost("{userId}/professor/{professorId}", Name = "AddProfessorToUser")]
        [Authorize]
        public IActionResult AddProfessorToUser(int professorId, int userId)
        {
            bool success = _usersCRUD.AddProfessorToUser(professorId, userId);
            if (!success)
            {
                return NotFound($"Professor with ID {professorId} or User with ID {userId} not found.");
            }

            return Ok();
        }

        // Remove um professor do user
        [HttpDelete("{userId}/professor/{professorId}", Name = "RemoveProfessorFromUser")]
        [Authorize]
        public IActionResult RemoveProfessorFromUser(int professorId, int userId)
        {
            bool success = _usersCRUD.RemoveProfessorFromUser(professorId, userId);
            if (!success)
            {
                return NotFound($"Professor with ID {professorId} or User with ID {userId} not found.");
            }

            return Ok();
        }

        // Lê todos os professores associados ao user
        [HttpGet("{UserId}/professor", Name = "GetAllProfessorsOfUser")]
        [Authorize]
        public IActionResult ReadAllProfessorsOfUser(int userId)
        {
            var professors = _usersCRUD.ReadAllProfessorsOfUser(userId);
            if (professors == null || !professors.Any())
            {
                return NotFound($"No professor found for User with ID {userId}.");
            }
            return Ok(professors);
        }

         // Adiciona um Student ao user
        [HttpPost("{userId}/student/{studentId}", Name = "AddStudentToUser")]
        [Authorize]
        public IActionResult AddStudentToUser(int studentId, int userId)
        {
            bool success = _usersCRUD.AddStudentToUser(studentId, userId);
            if (!success)
            {
                return NotFound($"Student with ID {studentId} or User with ID {userId} not found.");
            }

            return Ok();
        }

        // Remove um Student do user
        [HttpDelete("{userId}/stucent/{studentId}", Name = "RemoveStudentFromUser")]
        [Authorize]
        public IActionResult RemoveStudentFromUser(int studentId, int userId)
        {
            bool success = _usersCRUD.RemoveStudentToUser(studentId, userId);
            if (!success)
            {
                return NotFound($"Student with ID {studentId} or User with ID {userId} not found.");
            }

            return Ok();
        }

        // Lê todos os Students associados ao user
        [HttpGet("{UserId}/student", Name = "GetAllStudentsOfUser")]
        [Authorize]
        public IActionResult ReadAllStudentsOfUser(int userId)
        {
            var students = _usersCRUD.ReadAllStudentsOfUser(userId);
            if (students == null || !students.Any())
            {
                return NotFound($"No student found for User with ID {userId}.");
            }
            return Ok(students);
        }
    }
}