using Microsoft.AspNetCore.Mvc;
using VigilanceClearance.Application.DTOs.Requests;
using VigilanceClearance.Application.Interfaces;
using VigilanceClearance.Application.Interfaces.AllegationOfMisconductExamined_9Interface;
using VigilanceClearance.Application.Interfaces.IntegrityAgreedOrDoubtfuliNTERFACE;

namespace VigilanceClearance.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AllegationOfMisconductExamined_9Controller : ControllerBase
    {
        private readonly IAllegationOfMisconductExamined_9 _allegationOfMisconductExamined_9;
        private readonly ILogger<AllegationOfMisconductExamined_9Controller> _logger;
        private readonly ILogService _logService;

        public AllegationOfMisconductExamined_9Controller(IAllegationOfMisconductExamined_9 allegationOfMisconductExamined_9, ILogger<AllegationOfMisconductExamined_9Controller> logger, ILogService logService)
        {
            _allegationOfMisconductExamined_9 = allegationOfMisconductExamined_9;
            _logger = logger;
            _logService = logService;
        }



        [HttpGet]
        [Route("AllegationOfMisconductExamined")]
        public async Task<IActionResult> AllegationOfMisconductExamined(long id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var Response = await _allegationOfMisconductExamined_9.AllegationOfMisconductExamined_9GetById(id);


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
        [Route("AddAllegationOfMisconductExamined")]
        public async Task<IActionResult> AddAllegationOfMisconductExamined([FromBody] AllegationOfMisconductExamined modelobj)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var Response = await _allegationOfMisconductExamined_9.insertAllegationOfMisconductExamined(modelobj);

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
