using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VigilanceClearance.Application.DTOs.Model;
using VigilanceClearance.Application.Interfaces;

namespace VigilanceClearance.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles ="Admin")]
    public class AdminSecController : ControllerBase
    {
        private readonly IAuthService _auth;
        public AdminSecController(IAuthService auth) => _auth = auth;

        [HttpPost("register")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Register([FromBody] RegisterDto dto) =>
            Ok(await _auth.RegisterAsync(dto.Email, dto.Password, dto.Role));
               
        [HttpGet("get-role")]       
        public async Task<IActionResult> GetRole()
        {
            var result = await _auth.GetRoleAsync();
            return Ok(result);
        }

        [HttpGet("get-users")]       
        public async Task<IActionResult> GetAllUsers()
        {
            var result = await _auth.GetAllUsers();
            return Ok(result);
        }
        [HttpPost("add-role")]
        public async Task<IActionResult> AddRole([FromBody] string role)
        {
            if (string.IsNullOrWhiteSpace(role))
                return BadRequest("Role name cannot be empty.");

            var result = await _auth.CreateRoleAsync(role);
            return Ok(result);
        }


        [HttpPost("assign-role")]
        public async Task<IActionResult> AssignRole([FromBody] UserRole model)
        {
            if (model == null || string.IsNullOrWhiteSpace(model.Email) || string.IsNullOrWhiteSpace(model.Role))
                return BadRequest("Email and Role are required.");

            var result = await _auth.AssignRoleToUserAsync(model.Email, model.Role);
            return Ok(result);
        }


    }
}
