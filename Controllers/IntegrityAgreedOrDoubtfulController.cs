using Microsoft.AspNetCore.Mvc;
using VigilanceClearance.Application.Interfaces.OfficerDetailsInterface;
using VigilanceClearance.Application.Interfaces;
using VigilanceClearance.Application.Interfaces.IntegrityAgreedOrDoubtfuliNTERFACE;
using VigilanceClearance.Application.DTOs.Requests;

namespace VigilanceClearance.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IntegrityAgreedOrDoubtfulController   : ControllerBase
    {
        public readonly IIntegrityAgreedOrDoubtful _integrityAgreedOrDoubtful;
        private readonly ILogger<IntegrityAgreedOrDoubtfulController> _logger;
        private readonly ILogService _logService;
        public IntegrityAgreedOrDoubtfulController(IIntegrityAgreedOrDoubtful integrityAgreedOrDoubtful, ILogger<IntegrityAgreedOrDoubtfulController> logger, ILogService logService)
        {
            _integrityAgreedOrDoubtful = integrityAgreedOrDoubtful;
            _logger = logger;
            _logService = logService;
        }
        [HttpPost]
        [Route("IntegrityAgreedOrDoubtful")]
        public async Task<IActionResult> AddIntegrityAgreedOrDoubtful([FromBody] IntegrityAgreedOrDoubtfulInsert modelobj)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var Response = await _integrityAgreedOrDoubtful.IntegrityAgreedOrDoubtfulInsert(modelobj);

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
        [Route("IntegrityAgreedOrDoubtfulGetOfficerID")]
        public async Task<IActionResult> IntegrityAgreedOrDoubtfulGetOfficerID(long id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var Response = await _integrityAgreedOrDoubtful.IntegrityAgreedOrDoubtfulGetByOfficerID(id);


                return Ok(Response);
            }
            catch (Exception ex)
            {

                _logger.LogError(ex, "Failed to load IntegrityAgreedOrDoubtful data");
                await _logService.LogAsync(ex.Message, ex.StackTrace ?? "", "Error");
                return StatusCode(500, "Error");
            }

        }
    }
}
