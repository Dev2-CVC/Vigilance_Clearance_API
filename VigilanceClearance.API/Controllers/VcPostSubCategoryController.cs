using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VigilanceClearance.Application.DTOs.Requests;
using VigilanceClearance.Application.Interfaces;
using VigilanceClearance.Application.Interfaces.VcPostSubServiceInterface;

namespace VigilanceClearance.API.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    [Authorize]
    public class VcPostSubCategoryController : ControllerBase
    {
        private readonly IVcPostSubCategoryService _vcPostSubService;

        private readonly ILogger<VcPostSubCategoryController> _logger;
        private readonly ILogService _logService;
        public VcPostSubCategoryController(IVcPostSubCategoryService vcPostSubService, ILogger<VcPostSubCategoryController> logger, ILogService logService)
        {
            _vcPostSubService = vcPostSubService;
            _logger = logger;
            _logService = logService;
        }
       
        [HttpPost]
        [Route("VcPostSubCategoryInsert")]
        public async Task<IActionResult> VcPostSubCategoryInsert(VcPostSubCategoryInsert vcPostSubCategory)
        {
            try { 
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var Response = await _vcPostSubService.VcPostSubCategoryInsert(vcPostSubCategory);
            return Ok(Response);
        }
            catch (Exception ex)
            {

                _logger.LogError(ex, "Failed to load VC Post data");
                await _logService.LogAsync(ex.Message, ex.StackTrace ?? "", "Error");
                return StatusCode(500, "Error");
            }
        }
        [HttpPost]
        [Route("VcPostSubCategoryUpdate")]
        public async Task<IActionResult> VcPostSubCategoryUpdate (VcPostSubCategoryInsert vcPostSubCategory)
        {
            try { 
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var Response = await _vcPostSubService.VcPostSubCategoryUpdate(vcPostSubCategory);
            return Ok(Response);
        }
            catch (Exception ex)
            {

                _logger.LogError(ex, "Failed to load VC Post data");
                await _logService.LogAsync(ex.Message, ex.StackTrace ?? "", "Error");
                return StatusCode(500, "Error");
            }
        }
    }
}
