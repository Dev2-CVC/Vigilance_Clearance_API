using Microsoft.AspNetCore.Mvc;
using VigilanceClearance.Application.Interfaces.VcReferenceReceivedForInterface;
using VigilanceClearance.Application.Interfaces;
using VigilanceClearance.Infrastructure.Infrastructure.Persistence.DbContexts;
using Microsoft.AspNetCore.Authorization;

namespace VigilanceClearance.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MinistryController : Controller
    {
        private readonly VCDbContext _vCDbContext;
        public readonly IMinistry _ministry;
        private readonly ILogger<MinistryController> _logger;
        private readonly ILogService _logService;
        public MinistryController(VCDbContext vCDbContext, ILogger<MinistryController> logger, ILogService logService, IMinistry ministry)
        {
            _vCDbContext = vCDbContext;
            _logger = logger;
            _logService = logService;
            _ministry = ministry;
        }



        [HttpGet]
        [Route("GetReferenceListPendingWithMinistryApprover")]
        public async Task<IActionResult> GetReferenceListPendingWith_MinistryApprover(string MinCode,string Role)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var Response = await _ministry.GetReferenceListPendingWithMinistryApprover(MinCode, Role);


                return Ok(Response);
            }
            catch (Exception ex)
            {

                _logger.LogError(ex, "Failed to load Ministry data");
                await _logService.LogAsync(ex.Message, ex.StackTrace ?? "", "Error");
                return StatusCode(500, "Error");
            }

        }
    }
}
