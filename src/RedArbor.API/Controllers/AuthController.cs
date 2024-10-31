using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RedArbor.API.Services;

namespace RedArbor.API.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly TokenService _tokenService;

        public AuthController(TokenService tokenService)
        {
            _tokenService = tokenService;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginDto loginDto)
        {
            if (loginDto.Username == "userTest" && loginDto.Password == "RedArbor2024")
            {
                var token = _tokenService.GenerateToken(loginDto.Username);
                return Ok(new { Token = token });
            }

            return Unauthorized("Credenciales inválidas");
        }
    }

    public class LoginDto
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
