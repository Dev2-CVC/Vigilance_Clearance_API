using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Data;
using VigilanceClearance.Application.Common.Helpers;
using VigilanceClearance.Application.DTOs.Requests;
using VigilanceClearance.Application.DTOs.Responses;
using VigilanceClearance.Application.Interfaces;
using VigilanceClearance.Application.Interfaces.CBI_DealingHandInterface;
using VigilanceClearance.Infrastructure.Common.Helpers;
using VigilanceClearance.Infrastructure.Infrastructure.Persistence.DbContexts;

namespace VigilanceClearance.Application.Services.CBI_DealingHandService
{
    public class CBI_DealingHandService : ICBI_DealingHand
    {
        private readonly VCDbContext _vCDbContext;
        private readonly ILogger<CBI_DealingHandService> _logger;
        private readonly ILogService _logService;
        public CBI_DealingHandService(VCDbContext vCDbContext, ILogger<CBI_DealingHandService> logger, ILogService logService)
        {
            _vCDbContext = vCDbContext;
            _logger = logger;
            _logService = logService;
        }

        public async Task<BaseResponseModel> CVC_ForwardToCBI(int id)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@MasterReferenceID", id, DbType.Int64);


                var result = await DapperHelper.QueryAsync(
                    _vCDbContext,
                    "[usp_ForwardProposalTo_CBI]",
                    parameters
                );

                var entity = result;

                if (entity == null)
                {
                    return BaseResponseFactory.NotFound();
                }

                return BaseResponseFactory.Success(entity, ApplicationMessages.InsertSuccess);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to insert data for CVC_ForwardToCBI with ID: {Id}", id);

                await _logService.LogAsync(
                    $"Failed to insert data for CVC_ForwardToCBI with ID: {id}",
                    ex.StackTrace ?? "",
                    "Error"
                );

                return BaseResponseFactory.Error(ApplicationMessages.DataNotRetrivedError);
            }
        }
        

        public async Task<BaseResponseModel> FeebbackOf_CBI(FeebbackOfCbiInsert model)
            {

                try
                {
                var parameters = new[]
                                            {
                                                new SqlParameter("@OfficerId", (object?)model.OfficerId ?? DBNull.Value),
                                                new SqlParameter("@FeebbackOfCbi", (object?)model.FeebbackOfCbi ?? DBNull.Value),
                                                new SqlParameter("@CreatedBy", (object?)model.CreatedBy ?? DBNull.Value),
                                                new SqlParameter("@CreatedOn", (object?)model.CreatedOn ?? DBNull.Value),
                                                new SqlParameter("@CreatedBySessionId", (object?)model.CreatedBySessionId ?? DBNull.Value),
                                                new SqlParameter("@CreatedByIp", (object?)model.CreatedByIp ?? DBNull.Value),
                                                new SqlParameter("@UpdateBy", (object?)model.UpdateBy ?? DBNull.Value),
                                                new SqlParameter("@UpdatedOn", (object?)model.UpdatedOn ?? DBNull.Value),
                                                new SqlParameter("@UpdatedBySessionId", (object?)model.UpdatedBySessionId ?? DBNull.Value),
                                                new SqlParameter("@UpdatedByIp", (object?)model.UpdatedByIp ?? DBNull.Value),
                };


                var result = await _vCDbContext.Database.ExecuteSqlRawAsync("EXEC usp_tbl_Transaction_FeebbackOf_CBI_1_Insert @OfficerId, @FeebbackOfCbi, @CreatedBy, @CreatedOn, @CreatedBySessionId, @CreatedByIp, @UpdateBy, @UpdatedOn, @UpdatedBySessionId, @UpdatedByIp", parameters);
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
                    _logger.LogError(ex, "Failed to Insert usp_tbl_Transaction_FeebbackOf_CBI_1_Insert ");

                    await _logService.LogAsync(
                        $"Failed to Insert usp_tbl_Transaction_FeebbackOf_CBI_1_Insert ",
                        ex.StackTrace ?? "",
                        "Error"
                    );

                    return BaseResponseFactory.Error(ApplicationMessages.RecordNotInsertedError);
                }
            }

        public async Task<BaseResponseModel> OfficerDetailWithFeebbackOf_CBI(long masterReferenceID)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@MasterReferenceID", masterReferenceID, DbType.Int64);


                var result = await DapperHelper.QueryAsync(
                    _vCDbContext,
                    "[usp_GetCBIFeedback_ByOfficerID]",
                    parameters
                );

                var entity = result;

                if (entity == null)
                {
                    return BaseResponseFactory.NotFound();
                }

                return BaseResponseFactory.Success(entity, ApplicationMessages.DataRetrived);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to retrieve data for OfficerDetailWithFeebbackOf_CBI with ID: {Id}", masterReferenceID);

                await _logService.LogAsync(
                    $"Failed to retrieve data for OfficerDetailWithFeebbackOf_CBI with ID: {masterReferenceID}",
                    ex.StackTrace ?? "",
                    "Error"
                );

                return BaseResponseFactory.Error(ApplicationMessages.DataNotRetrivedError);
            }

        }
    }
    }

