using Microsoft.AspNetCore.Mvc;
using VigilanceClearance.Application.DTOs.RequestModel;
using VigilanceClearance.Application.Interfaces;
using VigilanceClearance.Application.Interfaces.DropDownServiceInterface;
using VigilanceClearance.Application.Interfaces.VcPostServiceInterface;

namespace VigilanceClearance.API.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    //[Authorize]
    public class VcPostController : ControllerBase
    {
        private readonly IVcPostService _vcPostService;

        private readonly ILogger<VcPostController> _logger;
        private readonly ILogService _logService;
        public VcPostController( IVcPostService vcPostService, IDropdownService dropDownService, ILogger<VcPostController> logger, ILogService logService)
        {
            _vcPostService = vcPostService;
            _logger = logger;
            _logService = logService;
        }


        [HttpPost]
        [Route("VcPostInsert")]
        public async Task<IActionResult> VcPostInsert([FromBody] VcPostInsert vcPostInsert)
        {
            try { 
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var Response = await _vcPostService.VcPostInsert(vcPostInsert);

            return Ok(Response);
        }
            catch (Exception ex) {

                _logger.LogError(ex, "Failed to load VC Post data");
                await _logService.LogAsync(ex.Message, ex.StackTrace ?? "", "Error"); 
                return StatusCode(500, "Error");
            }

            
        }
        [HttpPost]
        [Route("VcPostUpdate")]
        public async Task<IActionResult> VcPostUpdate([FromBody] VcPostInsert vcPostInsert)
        {
            try { 

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var Response = await _vcPostService.VcPostUpdate(vcPostInsert);

            return Ok(Response);
        }
            catch (Exception ex) {

                _logger.LogError(ex, "Failed to load VC Post data");
                await _logService.LogAsync(ex.Message, ex.StackTrace ?? "", "Error"); 
                return StatusCode(500, "Error");

            }
        }
        
       
       
    }
}
