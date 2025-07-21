using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VigilanceClearance.Application.Interfaces;
using VigilanceClearance.Application.Interfaces.OfficerDetailsInterface;
using VigilanceClearance.Application.Interfaces.UserInterface;

namespace VigilanceClearance.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        public readonly IUserInterface _UserInterface;
        private readonly ILogger<UserController> _logger;
        private readonly ILogService _logService;

        public UserController(IUserInterface UserInterface, ILogger<UserController> logger, ILogService logService)
        {
            _UserInterface = UserInterface;
            _logger = logger;
            _logService = logService;
        }


        [HttpGet]
        [Route("GetUserDetails")]
        public async Task<IActionResult> GetUserDetails(string UserName)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var Response = await _UserInterface.GetUserDetailsByUserName(UserName);

                return Ok(Response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to load OfficerDetail data");
                await _logService.LogAsync(ex.Message, ex.StackTrace ?? "", "Error");
                return StatusCode(500, "Error");
            }
        }


    }
}
