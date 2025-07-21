using Microsoft.AspNetCore.Mvc;
using VigilanceClearance.Application.DTOs.Requests;
using VigilanceClearance.Application.Interfaces;
using VigilanceClearance.Application.Interfaces.ActionContemplatedAgainstTheOfficer_12Interface;
using VigilanceClearance.Application.Interfaces.DisciplinaryCriminalProceedings_11Interface;

namespace VigilanceClearance.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActionContemplatedAgainstTheOfficer_12Controller : Controller
    {
        private readonly IActionContemplatedAgainstTheOfficer_12 _ActionContemplatedAgainstTheOfficer_12;
        private readonly ILogger<ActionContemplatedAgainstTheOfficer_12Controller> _logger;
        private readonly ILogService _logService;
        public ActionContemplatedAgainstTheOfficer_12Controller(IActionContemplatedAgainstTheOfficer_12 ActionContemplatedAgainstTheOfficer_12, ILogger<ActionContemplatedAgainstTheOfficer_12Controller> logger, ILogService logService)
        {
            _ActionContemplatedAgainstTheOfficer_12 = ActionContemplatedAgainstTheOfficer_12;
            _logger = logger;
            _logService = logService;
        }



        [HttpPost]
        [Route("addActionContemplatedAgainstTheOfficer")]
        public async Task<IActionResult> AddActionContemplatedAgainstTheOfficer([FromBody] ActionContemplatedAgainstTheOfficer modelobj)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var Response = await _ActionContemplatedAgainstTheOfficer_12.insertActionContemplatedAgainstTheOfficer(modelobj);

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
        [Route("getActionContemplatedAgainstTheOfficelist")]
        public async Task<IActionResult> GetActionContemplatedAgainstTheOfficelist(long id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var Response = await _ActionContemplatedAgainstTheOfficer_12.GetActionContemplatedAgainstTheOfficelistById(id);


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
