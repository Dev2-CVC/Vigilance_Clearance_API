using Microsoft.AspNetCore.Mvc;
using VigilanceClearance.Application.DTOs.Model;
using VigilanceClearance.Application.Interfaces;

namespace VigilanceClearance.API.Controllers
{
    [Route("api/[controller]"), ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _auth;
        public AuthController(IAuthService auth) => _auth = auth;

        //[HttpPost("register")]
        //public async Task<IActionResult> Register([FromBody] RegisterDto dto) =>
        //    Ok(await _auth.RegisterAsync(dto.Email, dto.Password, dto.Role));

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto dto)
        {
            var token = await _auth.LoginAsync(dto.Email, dto.Password);
            return token != null ? Ok(new { token }) : Unauthorized("Invalid creds");
        }

        //[HttpPost("add-role")]
        //public async Task<IActionResult> AddRole([FromBody] string role)
        //{
        //    if (string.IsNullOrWhiteSpace(role))
        //        return BadRequest("Role name cannot be empty.");

        //    var result = await _auth.CreateRoleAsync(role);
        //    return Ok(result);
        //}


        //[HttpPost("assign-role")]
        //public async Task<IActionResult> AssignRole([FromBody] UserRole model)
        //{
        //    if (model == null || string.IsNullOrWhiteSpace(model.Email) || string.IsNullOrWhiteSpace(model.Role))
        //        return BadRequest("Email and Role are required.");

        //    var result = await _auth.AssignRoleToUserAsync(model.Email, model.Role);
        //    return Ok(result);
        //}
    }

    public class UserRole
    {
        public string Email { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
    }

}
