using Microsoft.AspNetCore.Mvc;
using VigilanceClearance.Application.Common.Helpers;
using VigilanceClearance.Application.DTOs.Requests;
using VigilanceClearance.Application.Interfaces;
using VigilanceClearance.Application.Interfaces.ActionContemplatedAgainstTheOfficer_12Interface;
using VigilanceClearance.Application.Interfaces.ComplaintWithVigilanceAnglePending_13Interface;

namespace VigilanceClearance.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComplaintWithVigilanceAnglePending_13Controller : Controller
    {
        private readonly IComplaintWithVigilanceAnglePending _iComplaintWithVigilanceAnglePending;
        private readonly ILogger<ComplaintWithVigilanceAnglePending_13Controller> _logger;
        private readonly ILogService _logService;
        public ComplaintWithVigilanceAnglePending_13Controller(IComplaintWithVigilanceAnglePending complaintWithVigilanceAnglePending, ILogger<ComplaintWithVigilanceAnglePending_13Controller> logger, ILogService logService)
        {
            _iComplaintWithVigilanceAnglePending = complaintWithVigilanceAnglePending;
            _logger = logger;
            _logService = logService;
        }




        [HttpPost]
        [Route("addComplaintWithVigilanceAnglePending")]
        public async Task<IActionResult> AddComplaintWithVigilanceAnglePending([FromBody] ComplaintWithVigilanceAnglePending modelobj)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var Response = await _iComplaintWithVigilanceAnglePending.insertComplaintWithVigilanceAnglePending(modelobj);

                return Ok(Response);
            }

            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to load IntegrityAgreedOrDoubtful data");
                await _logService.LogAsync(ex.Message, ex.StackTrace ?? "", "Error");
                return StatusCode(500, "Error");
            }
        }
     
        [HttpGet]
        [Route("getComplaintWithVigilanceAnglePendinglist")]
        public async Task<IActionResult> GetComplaintWithVigilanceAnglePendinglist(long id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var Response = await _iComplaintWithVigilanceAnglePending.GetComplaintWithVigilanceAnglePendinglistById(id);


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
