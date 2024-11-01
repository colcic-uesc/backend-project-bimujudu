using Microsoft.AspNetCore.Mvc;
using UescColcicAPI.Services.Auth;
using UescColcicAPI.Services.BD.Interfaces;

namespace UescColcicAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _authService;
        private readonly IUsersCRUD _usersCRUD;

        public AuthController(AuthService authService, IUsersCRUD usersCRUD)
        {
            _authService = authService;
            _usersCRUD = usersCRUD;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            var user = _usersCRUD.ReadAll().FirstOrDefault(u => u.UserName == request.Username && u.Password == request.Password);

            if (user == null)
            {
                return Unauthorized("Invalid username or password.");
            }

            // Gerar o token JWT usando AuthService
            var token = _authService.GenerateJwtToken();

            return Ok(new { Token = token });
        }
    }

    public class LoginRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}