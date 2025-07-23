using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VigilanceClearance.Application.DTOs.Requests;
using VigilanceClearance.Application.Interfaces;
using VigilanceClearance.Application.Interfaces.DealingHand;
using VigilanceClearance.Application.Interfaces.VcReferenceInterface;

namespace VigilanceClearance.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class DealingHandController : Controller
    {
        private readonly IDealingHand _dealingHand;
        private readonly ILogger<DealingHandController> _logger;
        private readonly ILogService _logService;
        public DealingHandController(IDealingHand dealingHand, ILogger<DealingHandController> logger, ILogService logService)
        {
            _dealingHand = dealingHand;
            _logger = logger;
            _logService = logService;
        }

        [HttpGet]
        [Route("ReferencesPendingWithDealingHand")]
        public async Task<IActionResult> ReferencesPendingWithDealingHand(string branch)
        {
            string Branch = branch;
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var Response = await _dealingHand.GetPendingListFor_BranchDH(Branch);

                return Ok(Response);
            }
            catch (Exception ex)
            {

                _logger.LogError(ex, "Failed to load VC Post data");
                await _logService.LogAsync(ex.Message, ex.StackTrace ?? "", "Error");
                return StatusCode(500, "Error");
            }

        }

        [HttpGet]
        [Route("OfficerDetailsForCVCUsers")]
        public async Task<IActionResult> OfficerDetailsForCVCUsers(int masterRefid, string branch)
        {
            string Branch = branch;
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var Response = await _dealingHand.OfficerDetailsForCVCUsers_List(masterRefid, Branch);

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
        [Route("AddVigBranchComments")]
        public async Task<IActionResult> AddVigBranchComments([FromBody] VigBranchCommentsInsert vigBranchCommentsobj)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var Response = await _dealingHand.VigBranchCommentsInsert(vigBranchCommentsobj);

                return Ok(Response);
            }
            catch (Exception ex)
            {

                _logger.LogError(ex, "Failed to load Vig Branch Comments");
                await _logService.LogAsync(ex.Message, ex.StackTrace ?? "", "Error");
                return StatusCode(500, "Error");
            }

        }

        [HttpGet]
        [Route("GetVigBranchComments")]
        public async Task<IActionResult> GetVigBranchComments(long masterRefid, long Officerid)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var Response = await _dealingHand.GetVigBranchComments(masterRefid, Officerid);

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
