using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using VigilanceClearance.Application.Common.Helpers;
using VigilanceClearance.Application.DTOs.RequestModel;
using VigilanceClearance.Application.DTOs.Responses;
using VigilanceClearance.Application.Interfaces;
using VigilanceClearance.Application.Interfaces.VcPostServiceInterface;
using VigilanceClearance.Infrastructure.Common.Helpers;
using VigilanceClearance.Infrastructure.Infrastructure.Persistence.DbContexts;

namespace VigilanceClearance.Application.Services.VcPostService
{
    public class VcPostService : IVcPostService
    {
        public readonly VCDbContext _vCDbContext;
        private readonly ILogger<VcPostService> _logger;
        private readonly ILogService _logService;
        public VcPostService(VCDbContext vCDbContext, ILogger<VcPostService> logger, ILogService logService)
        {
            _vCDbContext = vCDbContext;
            _logger = logger;
            _logService = logService;
        }


        public async Task<BaseResponseModel> VcPostInsert(VcPostInsert vcPostInsert)
        {

            try
            {
                var parameters = new[]
                {
            new SqlParameter("@PostCode", vcPostInsert.PostCode),
            new SqlParameter("@PostDescription", vcPostInsert.PostDescription ),
            new SqlParameter("@CreatedBy", vcPostInsert.CreatedBy),
            new SqlParameter("@CreatedOn", vcPostInsert.CreatedOn),
            new SqlParameter("@CreatedBy_Ip", vcPostInsert.CreatedByIp ),
            new SqlParameter("@CreatedBy_Session", vcPostInsert.CreatedBySession ),
            new SqlParameter("@UpdateBy", vcPostInsert.UpdateBy ),
            new SqlParameter("@UpdatedOn", vcPostInsert.UpdatedOn),
            new SqlParameter("@UpdatedBy_SessionId", vcPostInsert.UpdatedBySessionId ),
            new SqlParameter("@UpdatedBy_IP", vcPostInsert.UpdatedByIp)
                };

                var result = await _vCDbContext.Database.ExecuteSqlRawAsync("EXEC usp_tbl_Master_Vc_Post_1_Insert @PostCode, @PostDescription, @CreatedBy, @CreatedOn, @CreatedBy_Ip, @CreatedBy_Session, @UpdateBy, @UpdatedOn, @UpdatedBy_SessionId, @UpdatedBy_IP", parameters);
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
                _logger.LogError(ex, "Failed to Insert usp_tbl_Master_Vc_Post_1_Insert ");

                await _logService.LogAsync(
                    $"Failed to Insert usp_tbl_Master_Vc_Post_1_Insert ",
                    ex.StackTrace ?? "",
                    "Error"
                );

                return BaseResponseFactory.Error(ApplicationMessages.RecordNotInsertedError);
            }
        }

        public async Task<BaseResponseModel> VcPostUpdate(VcPostInsert vcPostInsert)
        {

            try
            {
                var parameters = new[]
 {
                    new SqlParameter("@Id", vcPostInsert.Id.HasValue ? vcPostInsert.Id.Value : (object)DBNull.Value),
                    new SqlParameter("@PostCode", vcPostInsert.PostCode ?? (object)DBNull.Value),
                    new SqlParameter("@PostDescription", vcPostInsert.PostDescription ?? (object)DBNull.Value),
                    new SqlParameter("@UpdateBy", vcPostInsert.UpdateBy ?? (object)DBNull.Value),
                    new SqlParameter("@UpdatedOn", vcPostInsert.UpdatedOn ?? (object)DBNull.Value),
                    new SqlParameter("@UpdatedBy_SessionId", vcPostInsert.UpdatedBySessionId ?? (object)DBNull.Value),
                    new SqlParameter("@UpdatedBy_IP", vcPostInsert.UpdatedByIp ?? (object)DBNull.Value)
                };


                var result = await _vCDbContext.Database.ExecuteSqlRawAsync(
                    "EXEC usp_tbl_Master_Vc_Post_2_Update @Id, @PostCode, @PostDescription, @UpdateBy, @UpdatedOn, @UpdatedBy_SessionId, @UpdatedBy_IP", parameters
                );

                if (result > 0)
                {
                  

                    return BaseResponseFactory.Success(ApplicationMessages.UpdateSuccess);
                }
                else
                {

                    return BaseResponseFactory.UpdateFailed();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to Update usp_tbl_Master_Vc_Post_2_Update ");

                await _logService.LogAsync(
                    $"Failed to Update usp_tbl_Master_Vc_Post_2_Update ",
                    ex.StackTrace ?? "",
                    "Error"
                );

                return BaseResponseFactory.Error(ApplicationMessages.RecordUpdatedError);
            }

        }

        

    }
}
