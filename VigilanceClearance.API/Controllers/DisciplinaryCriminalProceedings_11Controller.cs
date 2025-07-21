using Microsoft.AspNetCore.Mvc;
using VigilanceClearance.Application.DTOs.Requests;
using VigilanceClearance.Application.Interfaces;
using VigilanceClearance.Application.Interfaces.DisciplinaryCriminalProceedings_11Interface;

namespace VigilanceClearance.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DisciplinaryCriminalProceedings_11Controller : Controller
    {
        private readonly IDisciplinaryCriminalProceedings_11 _disciplinaryCriminalProceedings_11;
        private readonly ILogger<DisciplinaryCriminalProceedings_11Controller> _logger;
        private readonly ILogService _logService;
        public DisciplinaryCriminalProceedings_11Controller(IDisciplinaryCriminalProceedings_11 disciplinaryCriminalProceedings_11, ILogger<DisciplinaryCriminalProceedings_11Controller> logger, ILogService logService)
        {
            _disciplinaryCriminalProceedings_11 = disciplinaryCriminalProceedings_11;
            _logger = logger;
            _logService = logService;
        }


        [HttpPost]
        [Route("addDisciplinaryCriminalProceedings")]
        public async Task<IActionResult> AddDisciplinaryCriminalProceedings([FromBody] DisciplinaryCriminalProceedings modelobj)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var Response = await _disciplinaryCriminalProceedings_11.insertDisciplinaryCriminalProceedings(modelobj);

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
        [Route("getdisciplinaryCriminalProceedingslist")]
        public async Task<IActionResult> GetdisciplinaryCriminalProceedingslist(long id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var Response = await _disciplinaryCriminalProceedings_11.GetdisciplinaryCriminalProceedingslistById(id);


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
