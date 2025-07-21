using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VigilanceClearance.Application.DTOs.Requests;
using VigilanceClearance.Application.Interfaces;
using VigilanceClearance.Application.Interfaces.DropDownServiceInterface;
using VigilanceClearance.Application.Interfaces.OfficerPostingDetailsInterface;

namespace VigilanceClearance.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class OfficerPostingDetailsController : ControllerBase
    {
        public readonly IOfficerPostingDetails _officerPostingDetails;
        private readonly ILogger<OfficerPostingDetailsController> _logger;
        private readonly ILogService _logService;

        public OfficerPostingDetailsController(IOfficerPostingDetails officerPostingDetails, ILogger<OfficerPostingDetailsController> logger, ILogService logService)
        {
            _officerPostingDetails = officerPostingDetails;
            _logger = logger;
            _logService = logService;
        }

        [HttpPost]
        [Route("addOfficerPostingDetails")]
        public async Task<IActionResult> AddOfficerPostingDetails([FromBody] OfficerPostingDetailsInsert modelobj)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var Response = await _officerPostingDetails.OfficerPostingDetailsInsert(modelobj);

                return Ok(Response);
            }
            catch (Exception ex)
            {

                _logger.LogError(ex, "Failed to load OP Post data");
                await _logService.LogAsync(ex.Message, ex.StackTrace ?? "", "Error");
                return StatusCode(500, "Error");
            }

        }

        [HttpGet]
        [Route("OfficerPostingDetailsGetById")]
        public async Task<IActionResult> OfficerPostingDetailsGetById(long id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var Response = await _officerPostingDetails.OfficerPostingDetailsGetById(id);


                return Ok(Response);
            }
            catch (Exception ex)
            {

                _logger.LogError(ex, "Failed to load OfficerDetail data");
                await _logService.LogAsync(ex.Message, ex.StackTrace ?? "", "Error");
                return StatusCode(500, "Error");
            }

        }
        [HttpGet]
        [Route("OfficerPostingDetailsGetByOfficerId")]
        public async Task<IActionResult> OfficerPostingDetailsGetByOfficerId(long id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var Response = await _officerPostingDetails.OfficerPostingDetailsGetByOfficerId(id);


                return Ok(Response);
            }
            catch (Exception ex)
            {

                _logger.LogError(ex, "Failed to load OfficerDetail data");
                await _logService.LogAsync(ex.Message, ex.StackTrace ?? "", "Error");
                return StatusCode(500, "Error");
            }

        }
        [HttpGet]
        [Route("GetOfficerPostingDetailsByPostingId")]
        public async Task<IActionResult> GetOfficerPostingDetailsByPostingId(long id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var Response = await _officerPostingDetails.GetOfficerPostingDetailsByPostingId(id);


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
