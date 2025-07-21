using Microsoft.AspNetCore.Mvc;
using VigilanceClearance.Application.Interfaces.OfficerPostingDetailsInterface;
using VigilanceClearance.Application.Interfaces;
using VigilanceClearance.Application.Interfaces.OfficerDetailsInterface;
using VigilanceClearance.Application.DTOs.Requests;
using Microsoft.AspNetCore.Authorization;

namespace VigilanceClearance.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class OfficerDetailsController : ControllerBase
    {

        public readonly IOfficerDetails _officerDetails;
        private readonly ILogger<OfficerDetailsController> _logger;
        private readonly ILogService _logService;

        public OfficerDetailsController(IOfficerDetails officerDetails, ILogger<OfficerDetailsController> logger, ILogService logService)
        {
            _officerDetails = officerDetails;
            _logger = logger;
            _logService = logService;
        }

        [HttpGet]
        [Route("OfficerDetailsGetById")]
        public async Task<IActionResult> OfficerDetailsGetById(long id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var Response = await _officerDetails.OfficerDetailsGetById(id);


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
        [Route("OfficerDetailsGetByMasterReferenceID")]
        public async Task<IActionResult> OfficerDetailsGetByMasterReferenceID(long id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var Response = await _officerDetails.OfficerDetailsGetByMasterReferenceID(id);


                return Ok(Response);
            }
            catch (Exception ex)
            {

                _logger.LogError(ex, "Failed to load OfficerDetail data");
                await _logService.LogAsync(ex.Message, ex.StackTrace ?? "", "Error");
                return StatusCode(500, "Error");
            }

        }
       

        [HttpPost]
        [Route("addOfficerDetails")]
        public async Task<IActionResult> AddOfficerDetails([FromBody] OfficerDetailsInsert modelobj)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var Response = await _officerDetails.OfficerDetailsInsert(modelobj);

                return Ok(Response);
            }
            catch (Exception ex)
            {

                _logger.LogError(ex, "Failed to load OP Post data");
                await _logService.LogAsync(ex.Message, ex.StackTrace ?? "", "Error");
                return StatusCode(500, "Error");
            }
        }


        #region Added as on date 16_07_2025

        [HttpGet]
        [Route("OfficerDetails_GetByOfficerId_ForMinistry")]
        public async Task<IActionResult> OfficerDetails_GetByOfficerId_ForMinistry(long OfficerId)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var Response = await _officerDetails.OfficerDetails_GetByOfficerId_ForMinistry(OfficerId);
                return Ok(Response);
            }
            catch (Exception ex)
            {

                _logger.LogError(ex, "Failed to load OfficerDetail data");
                await _logService.LogAsync(ex.Message, ex.StackTrace ?? "", "Error");
                return StatusCode(500, "Error");
            }
        }

        #endregion



    }
}
