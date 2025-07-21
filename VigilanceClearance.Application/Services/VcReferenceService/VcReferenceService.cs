using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using VigilanceClearance.Application.DTOs.Requests;
using VigilanceClearance.Application.DTOs.Responses;
using VigilanceClearance.Application.Interfaces;
using VigilanceClearance.Application.Interfaces.VcReferenceInterface;
using VigilanceClearance.Application.Services.VcPostSubService;
using VigilanceClearance.Infrastructure.Common.Helpers;
using VigilanceClearance.Infrastructure.Infrastructure.Persistence.DbContexts;

namespace VigilanceClearance.Application.Services.VcReferenceService
{
    public class VcReferenceService : IVcReference
    {
        public readonly VCDbContext _vCDbContext;
        private readonly ILogger<VcPostSubCategoryService> _logger;
        private readonly ILogService _logService;
        public VcReferenceService(VCDbContext vCDbContext, ILogger<VcPostSubCategoryService> logger, ILogService logService)
        {
            _vCDbContext = vCDbContext;
            _logger = logger;
            _logService = logService;
        }

 //       public async Task<VcReferenceInsert> VcReferenceGetById(VcReferenceGet vcReferenceget)
 //       {
 //           try
 //           {
 //               var parameters = new[]
 //{
 //                   new SqlParameter("@id", vcReferenceget.Id.HasValue ? vcReferenceget.Id.Value : (object)DBNull.Value),
 //                   new SqlParameter("@UserName", vcReferenceget.UserName ?? (object)DBNull.Value),

 //               };


 //               var result = await _vCDbContext.Database.ExecuteSqlRawAsync(
 //                   "EXEC usp_tbl_Master_Vc_Post_2_Update @id, @UserName", parameters
 //               );
 //               //var entity = result.FirstOrDefault();

 //               if (entity == null)
 //                   return null;
 //               var dto = new VcReferenceInsert
 //               {
 //                   Id = result.Refer,
 //                   PostCode = entity.PostCode,
 //                   PostDescription = entity.PostDescription,
 //                   CreatedBy = entity.CreatedBy,
 //                   CreatedOn = entity.CreatedOn,
 //                   CreatedByIp = entity.CreatedByIp,
 //                   CreatedBySession = entity.CreatedBySession,
 //                   UpdateBy = entity.UpdateBy,
 //                   UpdatedOn = entity.UpdatedOn,
 //                   UpdatedBySessionId = entity.UpdatedBySessionId,
 //                   UpdatedByIp = entity.UpdatedByIp
 //               };
 //               return dto;
 //           }
 //           catch (Exception ex)
 //           {
 //               BaseResponseModel responsemodel = new BaseResponseModel()

 //               {
 //                   IsSuccess = false,
 //                   Message = "Error Occured  Record Not Updated Successfully"
 //               };
 //               return new VcReferenceInsert();
 //           }


 //       }

        public async Task<BaseResponseModel> VcReferenceInsert(VcReferenceInsert vcReferenceInsert)
        {
            try
            {
                var parameters = new[]
                {
            new SqlParameter("@ReferenceDesc", vcReferenceInsert.ReferenceDesc),
            new SqlParameter("@ReferenceCode", vcReferenceInsert.ReferenceCode),
             new SqlParameter("@CreatedBy", vcReferenceInsert.CreatedBy),
              new SqlParameter("@CreatedOn", vcReferenceInsert.CreatedOn),
               new SqlParameter("@CreatedBy_SessionId", vcReferenceInsert.CreatedBySessionId),
                new SqlParameter("@CreatedBy_IP", vcReferenceInsert.CreatedByIp),
                 new SqlParameter("@UpdateBy", vcReferenceInsert.UpdateBy),
                  new SqlParameter("@UpdatedOn", vcReferenceInsert.UpdatedOn),
                  new SqlParameter("@UpdatedBy_SessionId", vcReferenceInsert.UpdatedBySessionId),
                  new SqlParameter("@UpdatedBy_IP", vcReferenceInsert.UpdatedByIp),
                };

                var result = await _vCDbContext.Database.ExecuteSqlRawAsync("EXEC usp_tbl_Master_Vc_Reference_1_Insert @ReferenceDesc, @ReferenceCode, @CreatedBy, @CreatedOn, @CreatedBy_SessionId,@CreatedBy_IP, @UpdateBy, @UpdatedOn, @UpdatedBy_SessionId, @UpdatedBy_IP", parameters);
                if (result > 0)
                {
                  
                    return BaseResponseFactory.Success();
                }
                else
                {

                   

                    return BaseResponseFactory.InsertFailed();
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to Insert usp_tbl_Master_Vc_Reference_1_Insert ");

                await _logService.LogAsync(
                    $"Failed to Insert usp_tbl_Master_Vc_Reference_1_Insert ",
                    ex.StackTrace ?? "",
                    "Error"
                );

                return BaseResponseFactory.Error();
            }
        }
    }
}
