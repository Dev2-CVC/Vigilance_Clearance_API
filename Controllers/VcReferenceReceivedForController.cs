using Microsoft.AspNetCore.Mvc;
using VigilanceClearance.Application.Interfaces;
using VigilanceClearance.Application.Interfaces.VcReferenceReceivedForInterface;
using VigilanceClearance.Infrastructure.Infrastructure.Persistence.DbContexts;
using VigilanceClearance.Infrastructure.Infrastructure.Persistence.Models;

namespace VigilanceClearance.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class VcReferenceReceivedForController : ControllerBase
    {
        private readonly VCDbContext _vCDbContext;
        public readonly IVcReferenceReceivedFor _vcReferenceReceivedFor;
        private readonly ILogger<VcReferenceReceivedForController> _logger;
        private readonly ILogService _logService;
        public VcReferenceReceivedForController(VCDbContext vCDbContext, ILogger<VcReferenceReceivedForController> logger, ILogService logService, IVcReferenceReceivedFor vcReferenceReceivedFor)
        {
            _vCDbContext = vCDbContext;
            _logger = logger;
            _logService = logService;
            _vcReferenceReceivedFor = vcReferenceReceivedFor;
        }
        [HttpGet]
        [Route("VcReferenceReceivedForGetById")]
        public async Task<IActionResult> VcReferenceReceivedForGetById(long id,string UserName)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var Response = await _vcReferenceReceivedFor.VcReferenceReceivedForGetById(id,UserName);


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
        [Route("VcReferenceReceivedForInsert")]
        public async Task<IActionResult> VcReferenceReceivedForInsert([FromBody]TblMasterVcReferenceReceivedFor vcReferenceReceivedFor)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var Response = await _vcReferenceReceivedFor.VcReferenceReceivedForInsert(vcReferenceReceivedFor);


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
