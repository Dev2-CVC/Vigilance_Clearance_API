using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace VigilanceClearance.API.Controllers
{

    [ApiController]
    [Route("api/[controller]")]   
    public class SampleController : ControllerBase
    {
        [Authorize(Roles = "User")]        
        [HttpGet("user")]
        public IActionResult user() => Ok("Hello, user!");

        [Authorize(Roles = "User")]
        [HttpGet("sudarshan")]
        public IActionResult sudarshan() => Ok("Hello, Sudarshan!");

        [Authorize(Roles = "Admin")]
        [HttpGet("admin")] 
        public IActionResult Admin() => Ok("Hello, admin!");

        [Authorize]
        [HttpGet("comman")]
        public IActionResult comman() => Ok("Hello, This is comman section!");
    }

}
