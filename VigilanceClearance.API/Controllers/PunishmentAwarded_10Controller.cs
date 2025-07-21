using Microsoft.AspNetCore.Mvc;
using VigilanceClearance.Application.DTOs.Requests;
using VigilanceClearance.Application.Interfaces;
using VigilanceClearance.Application.Interfaces.AllegationOfMisconductExamined_9Interface;

namespace VigilanceClearance.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PunishmentAwarded_10Controller : ControllerBase
    {
        private readonly IPunishmentAwarded_10 _IPunishmentAwarded_10;
        private readonly ILogger<PunishmentAwarded_10Controller> _logger;
        private readonly ILogService _logService;

        public PunishmentAwarded_10Controller(IPunishmentAwarded_10 IPunishmentAwarded_10, ILogger<PunishmentAwarded_10Controller> logger, ILogService logService)
        {
            _IPunishmentAwarded_10 = IPunishmentAwarded_10;
            _logger = logger;
            _logService = logService;
        }
        

        [HttpPost]
        [Route("AddPunishmentAwarded")]
        public async Task<IActionResult> AddPunishmentAwarded([FromBody] PunishmentAwarded modelobj)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var Response = await _IPunishmentAwarded_10.insertPunishmentAwarded(modelobj);

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
        [Route("GetPunishmentAwardedlist")]
        public async Task<IActionResult> GetPunishmentAwardedlist(long id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var Response = await _IPunishmentAwarded_10.GetPunishmentAwardedlistGetById(id);


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
