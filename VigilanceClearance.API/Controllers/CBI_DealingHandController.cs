using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VigilanceClearance.Application.DTOs.Requests;
using VigilanceClearance.Application.Interfaces;
using VigilanceClearance.Application.Interfaces.CBI_DealingHandInterface;

namespace VigilanceClearance.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CBI_DealingHandController : ControllerBase
    {
        public readonly ICBI_DealingHand _DealingHand;
        private readonly ILogger<VcReferenceController> _logger;
        private readonly ILogService _logService;
        public CBI_DealingHandController(ICBI_DealingHand DealingHand, ILogger<VcReferenceController> logger, ILogService logService)
        {
            _DealingHand = DealingHand;
            _logger = logger;
            _logService = logService;
        }
        [HttpPost]
        [Route("FeebbackOf_CBI")]
        public async Task<IActionResult> FeebbackOf_CBI([FromBody] FeebbackOfCbiInsert model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var Response = await _DealingHand.FeebbackOf_CBI(model);

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
        [Route("CVC_ForwardToCBI")]
        public async Task<IActionResult> CVC_ForwardToCBI([FromBody] int id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var Response = await _DealingHand.CVC_ForwardToCBI(id);

                return Ok(Response);
            }
            catch (Exception ex)
            {

                _logger.LogError(ex, "Failed to insert CBI Post data");
                await _logService.LogAsync(ex.Message, ex.StackTrace ?? "", "Error");
                return StatusCode(500, "Error");
            }

        }
        [HttpGet]
        [Route("OfficerDetailWithFeebbackOf_CBI")]
        public async Task<IActionResult> OfficerDetailWithFeebbackOf_CBI(string id)
        {
            long masterReferenceID = Convert.ToInt64(id);
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var Response = await _DealingHand.OfficerDetailWithFeebbackOf_CBI(masterReferenceID);

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
