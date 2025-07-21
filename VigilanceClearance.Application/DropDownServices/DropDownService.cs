using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using VigilanceClearance.Application.DTOs.RequestModel;
using VigilanceClearance.Application.DTOs.Responses;
using VigilanceClearance.Application.Interfaces;
using VigilanceClearance.Application.Interfaces.DropDownServiceInterface;
using VigilanceClearance.Infrastructure.Infrastructure.Persistence.DbContexts;

namespace VigilanceClearance.Application.DropDownServices
{
    public class DropDownService : IDropdownService
    {
   
        public readonly VCDbContext _vCDbContext;
        private readonly ILogger<DropDownService> _logger;
        private readonly ILogService _logService;
        public DropDownService(VCDbContext vCDbContext, ILogger<DropDownService> logger, ILogService logService)
        {
            _vCDbContext = vCDbContext;
            _logger = logger;
            _logService = logService;
        }
        public async Task<List<DropDownResponseModel>> VcPostGetAll()
        {
            try
            {
                var result = await _vCDbContext.TblMasterVcPosts
                    .Select(x => new DropDownResponseModel
                    {
                        Text = x.PostDescription!,
                        Value = x.PostCode!
                    })
                    .ToListAsync();

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to load VcReferenceGetAll for id");

                await _logService.LogAsync(
                    $"Failed to load VcReferenceGetAll ",
                    ex.StackTrace ?? "",
                    "Error"
                );

                throw;
            }
        }
        public async Task<List<DropDownResponseModel>> VcReferenceGetAll()
        {
            try
            {
                var result = await _vCDbContext.TblMasterVcReferences
                    .Select(x => new DropDownResponseModel
                    {
                        Text = x.ReferenceDesc!,
                        Value = x.ReferenceCode!
                    })
                    .ToListAsync();

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to load VcReferenceGetAll for id");

                await _logService.LogAsync(
                    $"Failed to load VcReferenceGetAll ",
                    ex.StackTrace ?? "",
                    "Error"
                );

                throw;
            
            }
        }

        public async Task<VcPostInsert> VcPostGetById(string id)
        {
            try
            {
                var param = new SqlParameter("@Id", id);

                var resultList = await _vCDbContext.TblMasterVcPosts
                    .FromSqlRaw("EXEC usp_tbl_Master_Vc_Post_4_GetById @Id", param)
                    .ToListAsync();

                var entity = resultList.FirstOrDefault();

                if (entity == null)
                    return null;
                var dto = new VcPostInsert
                {
                    Id = entity.Id,
                    PostCode = entity.PostCode,
                    PostDescription = entity.PostDescription,
                    CreatedBy = entity.CreatedBy,
                    CreatedOn = entity.CreatedOn,
                    CreatedByIp = entity.CreatedByIp,
                    CreatedBySession = entity.CreatedBySession,
                    UpdateBy = entity.UpdateBy,
                    UpdatedOn = entity.UpdatedOn,
                    UpdatedBySessionId = entity.UpdatedBySessionId,
                    UpdatedByIp = entity.UpdatedByIp
                };
                return dto;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to load usp_tbl_Master_Vc_Post_4_GetById for id: {id}", id);

                await _logService.LogAsync(
                    $"Failed to load usp_tbl_Master_Vc_Post_4_GetById for id: {id}",
                    ex.StackTrace ?? "",
                    "Error"
                );

                throw;
            }
            }
        public async Task<List<DropDownResponseModel>> VcPostGetByReferenceNumber(string ReferenceNumber)
        {
            try
            {
                var param = new SqlParameter("@ReferenceCode", ReferenceNumber);

                var resultList = await _vCDbContext.Database
                    .SqlQueryRaw<DropDownResponseModel>("EXEC usp_tbl_Master_Vc_Post_4_GetByReferenceCode @ReferenceCode", param)
                    .ToListAsync();               
                return resultList;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to load Master_Vc_Post for GetByReferenceCode: {Section}", ReferenceNumber);

                await _logService.LogAsync(
                    $"Failed to load Master_Vc_Post for GetByReferenceCode: {ReferenceNumber}",
                    ex.StackTrace ?? "",
                    "Error"
                );

                throw;
            }
        }

        public async Task<List<DropDownResponseModel>> VcPostSubCategoryGetById(string id)
        {
            try
            {
                var param = new SqlParameter("@selectionForThePostCategory", id);

                var resultList = await _vCDbContext.TblMasterVcPost
                    .FromSqlRaw("EXEC usp_tbl_Master_Vc_Post_SubCategory_4_GetById @selectionForThePostCategory", param)
                    .ToListAsync();



                if (resultList == null || !resultList.Any())
                    return new List<DropDownResponseModel>();

                var dtoList = resultList.Select(entity => new DropDownResponseModel
                {

                    Text = entity.SelectionForThePostCategorySubCodeDesc,
                    Value = entity.SelectionForThePostCategorySubCode
                }).ToList();

                return dtoList;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to load subcategory for VC Post ID: {PostId}", id);

                await _logService.LogAsync(
                    $"Failed to load subcategory for VC Post ID: {id}",
                    ex.StackTrace ?? "",
                    "Error"
                );

                throw; 
            }
        }
        public async Task<List<DropDownResponseModel>> MinistryNewGetBySection(string Section)
        {
            try
            {
                var param = new SqlParameter("@section", Section);

                var resultList = await _vCDbContext.TblMasterVcMinistryNews
                    .FromSqlRaw("EXEC usp_tbl_Master_Vc_MinistryNew_5_GetAll @section", param)
                    .ToListAsync();

                if (resultList == null || !resultList.Any())
                    return new List<DropDownResponseModel>();

                var dtoList = resultList.Select(entity => new DropDownResponseModel
                {
                    Text = entity.OrgName,
                    Value = entity.OrgCode
                }).ToList();

                return dtoList;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to load Vc_MinistryNew for section: {Section}", Section);

                await _logService.LogAsync(
                    $"Failed to load Vc_MinistryNew for section: {Section}",
                    ex.StackTrace ?? "",
                    "Error"
                );

                throw;
            }
        }
        public async Task<List<DropDownResponseModel>> GetMinistryByOrgCode(string orgcode)
        {
            try
            {
                var param = new SqlParameter("@orgcode", orgcode);

                var resultList = await _vCDbContext.TblMasterVcMinistries
                    .FromSqlRaw("EXEC usp_tbl_Master_Vc_Ministry_5_GetMinCode @orgcode", param)
                    .ToListAsync();

                if (resultList == null || !resultList.Any())
                    return new List<DropDownResponseModel>();

                var dtoList = resultList.Select(entity => new DropDownResponseModel
                {
                    Text = entity.MinName,
                    Value = entity.MinCode
                }).ToList();

                return dtoList;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to load Ministry_5_GetMinCode for orgcode: {orgcode}", orgcode);

                await _logService.LogAsync(
                    $"Failed to load Ministry_5_GetMinCode for orgcode: {orgcode}",
                    ex.StackTrace ?? "",
                    "Error"
                );

                throw;
            }
        }


        #region Added as on date 03_07_2025
        public async Task<List<DropDownResponseModel>> GetAllService()
        {
            try
            {
                var result = await _vCDbContext.TblMasterVcServiceNews
                    .Select(x => new DropDownResponseModel
                    {
                        Text = x.ServiceName!,
                        Value = x.ServiceCode!
                    })
                    .ToListAsync();

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to load VcReferenceGetAll for id");

                await _logService.LogAsync(
                    $"Failed to load VcReferenceGetAll ",
                    ex.StackTrace ?? "",
                    "Error"
                );

                throw;

            }
        }


        public async Task<List<DropDownResponseModel>> GetAllCadre()
        {
            try
            {
                var result = await _vCDbContext.MasterVcCadres
                    .Select(x => new DropDownResponseModel
                    {
                        Text = x.CadreDesc!,
                        Value = x.CadreType!
                    })
                    .ToListAsync();

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to load VcReferenceGetAll for id");

                await _logService.LogAsync(
                    $"Failed to load VcReferenceGetAll ",
                    ex.StackTrace ?? "",
                    "Error"
                );
                throw;
            }
        }


        public async Task<List<DropDownResponseModel>> GetOrgByMinCode(string Mincode)
        {
            try
            {
                var param = new SqlParameter("@MinCode", Mincode);

                var resultList = await _vCDbContext.TblMasterVcMinistryNews
                    .FromSqlRaw("EXEC usp_GetOrgByMinCode @MinCode", param)
                    .ToListAsync();

                if (resultList == null || !resultList.Any())
                    return new List<DropDownResponseModel>();

                var dtoList = resultList.Select(entity => new DropDownResponseModel
                {
                    Text = entity.OrgName,
                    Value = entity.OrgCode
                }).ToList();

                return dtoList;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to load Ministry_5_GetMinCode for Mincode: {Mincode}", Mincode);

                await _logService.LogAsync(
                    $"Failed to load Ministry_5_GetMinCode for Mincode: {Mincode}",
                    ex.StackTrace ?? "",
                    "Error"
                );

                throw;
            }
        }
       
        #endregion
    }
}
