using Microsoft.AspNetCore.Mvc;
using VigilanceClearance.Application.DTOs.Requests;
using VigilanceClearance.Application.Interfaces;
using VigilanceClearance.Application.Interfaces.DropDownServiceInterface;
using VigilanceClearance.Application.Interfaces.VcReferenceInterface;

namespace VigilanceClearance.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VcReferenceController : ControllerBase
    {
        public IDropdownService _dropdownService;
        public readonly IVcReference _vcReference;
        private readonly ILogger<VcReferenceController> _logger;
        private readonly ILogService _logService;
        public VcReferenceController(IVcReference vcReference, IDropdownService dropdownService, ILogger<VcReferenceController> logger, ILogService logService)
        {
            _vcReference= vcReference;
            _dropdownService = dropdownService;
            _logger = logger;
            _logService = logService;
        }
        [HttpPost]
        [Route("VcReferenceInsert")]
        public async Task<IActionResult> VcReferenceInsert([FromBody] VcReferenceInsert vcReferenceInsert)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var Response = await _vcReference.VcReferenceInsert(vcReferenceInsert);

                return Ok(Response);
            }
            catch (Exception ex)
            {

                _logger.LogError(ex, "Failed to load VC Post data");
                await _logService.LogAsync(ex.Message, ex.StackTrace ?? "", "Error");
                return StatusCode(500, "Error");
            }

        }
        //[HttpPost]
        //[Route("VcReferenceGetById")]
        //public async Task<IActionResult> VcReferenceGetById([FromBody] VcReferenceGet vcReferenceget)
        //{
        //    try
        //    {
        //        if (!ModelState.IsValid)
        //        {
        //            return BadRequest(ModelState);
        //        }
        //        var Response = await _vcReference.VcReferenceGetById(vcReferenceget);

        //        return Ok(Response);
        //    }
        //    catch (Exception ex)
        //    {

        //        return StatusCode(500, new
        //        {
        //            message = "Internal Server Error",
        //            error = ex.Message
        //        });

        //    }
        //}
    }
}
