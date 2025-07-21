using Microsoft.AspNetCore.Mvc;
using VigilanceClearance.Application.Interfaces;
using VigilanceClearance.Application.Interfaces.DropDownServiceInterface;

namespace VigilanceClearance.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class DropDownController : ControllerBase
    {
        public readonly IDropdownService _dropdownService;
        private readonly ILogger<VcPostSubCategoryController> _logger;
        private readonly ILogService _logService;
        public DropDownController(IDropdownService dropdownService, ILogger<VcPostSubCategoryController> logger, ILogService logService)
        {
            _dropdownService = dropdownService;
            _logger = logger;
            _logService = logService;
        }
        [HttpGet]
        [Route("VcGetAll")]
        public async Task<IActionResult> VcPostGetAll()
        {
            try
            {
                var Response = await _dropdownService.VcPostGetAll();
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
        [Route("VcReferenceGetAll")]
        public async Task<IActionResult> VcReferenceGetAll()
        {
            try
            {
                var Response = await _dropdownService.VcReferenceGetAll();
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
        [Route("VcPostGetById")]
        public async Task<IActionResult> VcPostGetById(string Id)
        {
            try
            {

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var Response = await _dropdownService.VcPostGetById(Id);
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
        [Route("VcPostSubCategoryGetById")]
        public async Task<IActionResult> VcPostSubCategoryGetById(string Id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var Response = await _dropdownService.VcPostSubCategoryGetById(Id);
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
        [Route("VcPostGetByReferenceNumber")]
        public async Task<IActionResult> VcPostGetByReferenceNumber(string ReferenceNumber)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var Response = await _dropdownService.VcPostGetByReferenceNumber(ReferenceNumber);
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
        [Route("MinistryNewGetBySection")]
        public async Task<IActionResult> MinistryNewGetBySection(string section)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var Response = await _dropdownService.MinistryNewGetBySection(section);
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
        [Route("GetMinistryByOrgCode")]
        public async Task<IActionResult> GetMinistryByOrgCode(string orgcode)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var Response = await _dropdownService.GetMinistryByOrgCode(orgcode);
                return Ok(Response);
            }
            catch (Exception ex)
            {

                _logger.LogError(ex, "Failed to load VC Post data");
                await _logService.LogAsync(ex.Message, ex.StackTrace ?? "", "Error");
                return StatusCode(500, "Error");
            }
        }

        #region Added as on date 03_07_2025
       
        [HttpGet]
        [Route("ServiceGetAll")]
        public async Task<IActionResult> ServiceGetAll()
        {
            try
            {
                var Response = await _dropdownService.GetAllService();
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
        [Route("CadreGetAll")]
        public async Task<IActionResult> CadreGetAll()
        {
            try
            {
                var Response = await _dropdownService.GetAllCadre();
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
        [Route("GetOrgByMinCode")]
        public async Task<IActionResult> GetOrgByMinCode(string Mincode )
        {
            try
            {
                var Response = await _dropdownService.GetOrgByMinCode(Mincode);
                return Ok(Response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to load VC Post data");
                await _logService.LogAsync(ex.Message, ex.StackTrace ?? "", "Error");
                return StatusCode(500, "Error");
            }
        }



        #endregion

    }
}
