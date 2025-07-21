using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VigilanceClearance.Application.DTOs.Requests;
using VigilanceClearance.Application.Interfaces;
using VigilanceClearance.Application.Interfaces.OfficerPostingDetailsInterface;

namespace VigilanceClearance.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class Coord2_DealingHandController : ControllerBase
    {
        public readonly ICoord2_DealingHand _DealingHand;
        private readonly ILogger<Coord2_DealingHandController> _logger;
        private readonly ILogService _logService;
        public Coord2_DealingHandController(ICoord2_DealingHand DealingHand, ILogger<Coord2_DealingHandController> logger, ILogService logService)
        {
            _DealingHand = DealingHand;
            _logger = logger;
            _logService = logService;
        }
       
        [HttpGet]
        [Route("OfficerDetailWithPostingDetails")]
        public async Task<IActionResult> OfficerDetailWithPostingDetails(string id)
        {
            long masterReferenceID = Convert.ToInt64(id);
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var Response = await _DealingHand.OfficerDetailWithPostingDetails(masterReferenceID);

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
        [Route("ForwardProposalTo_BranchesAndMinistry")]
        public async Task<IActionResult> ForwardProposalTo_BranchesAndMinistry([FromBody] ForwardProposalTo_BranchesAndMinistryModel modelobj)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var Response = await _DealingHand.ForwardProposalTo_BranchesAndMinistry(modelobj);

                return Ok(Response);
            }
            catch (Exception ex)
            {

                _logger.LogError(ex, "Failed to load OP Post data");
                await _logService.LogAsync(ex.Message, ex.StackTrace ?? "", "Error");
                return StatusCode(500, "Error");
            }

        }
    }
}
