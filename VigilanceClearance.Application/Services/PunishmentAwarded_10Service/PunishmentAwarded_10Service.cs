using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VigilanceClearance.Application.Common.Helpers;
using VigilanceClearance.Application.DTOs.Requests;
using VigilanceClearance.Application.DTOs.Responses;
using VigilanceClearance.Application.Interfaces;
using VigilanceClearance.Infrastructure.Common.Helpers;
using VigilanceClearance.Infrastructure.Infrastructure.Persistence.DbContexts;

namespace VigilanceClearance.Application.Services.PunishmentAwarded_10Service
{

    public class PunishmentAwarded_10Service : IPunishmentAwarded_10
    {
        private readonly VCDbContext _vCDbContext;
        private readonly ILogger<PunishmentAwarded_10Service> _logger;
        private readonly ILogService _logService;
        public PunishmentAwarded_10Service(VCDbContext vCDbContext, ILogger<PunishmentAwarded_10Service> logger, ILogService logService)
        {
            _vCDbContext = vCDbContext;
            _logger = logger;
            _logService = logService;
        }

        public async Task<BaseResponseModel> insertPunishmentAwarded(PunishmentAwarded punishmentAwardedModel)
        {
            try
            {
                var parameters = new[]
                {
                     new SqlParameter("@MasterReferenceId", punishmentAwardedModel.MasterReferenceId),
                      new SqlParameter("@officerId", punishmentAwardedModel.officerId),
                      new SqlParameter("@punishmentAwarded", punishmentAwardedModel.punishmentAwarded),
                      new SqlParameter("@punishmentDetails", punishmentAwardedModel.punishmentDetails),
                      new SqlParameter("@punishmentFromDate", punishmentAwardedModel.punishmentFromDate),
                      new SqlParameter("@punishmentToDate", punishmentAwardedModel.punishmentToDate),
                      new SqlParameter("@checkName_FromDate", punishmentAwardedModel.checkName_FromDate),
                      new SqlParameter("@checkName_ToDate", punishmentAwardedModel.checkName_ToDate),
                      new SqlParameter("@additionalRemarks_IfAny", punishmentAwardedModel.additionalRemarks_IfAny),
                      new SqlParameter("@CreatedBy", punishmentAwardedModel.ActionBy),
                      new SqlParameter("@CreatedBy_SessionId", punishmentAwardedModel.ActionBy_SessionId),
                      new SqlParameter("@CreatedBy_IP", punishmentAwardedModel.ActionBy_IP)
                };

                var result = await _vCDbContext.Database.ExecuteSqlRawAsync(
                              @"EXEC usp_tbl_Transaction_10_PunishmentAwarded_1_Insert 
                               @MasterReferenceId,
                               @officerId, 
                               @punishmentAwarded, 
                               @punishmentDetails, 
                               @punishmentFromDate, 
                               @punishmentToDate, 
                               @checkName_FromDate, 
                               @checkName_ToDate, 
                               @additionalRemarks_IfAny, 
                               @CreatedBy, 
                               @CreatedBy_SessionId, 
                               @CreatedBy_IP",

                 parameters);

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
                _logger.LogError(ex, "Failed to Insert usp_tbl_Transaction_10_PunishmentAwarded_1_Insert");

                await _logService.LogAsync(
                    $"Failed to Insert usp_tbl_Transaction_10_PunishmentAwarded_1_Insert",
                    ex.StackTrace ?? "",
                    "Error"
                );

                return BaseResponseFactory.Error();
            }
        }


        public async Task<BaseResponseModel> GetPunishmentAwardedlistGetById(long? id)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@id", id, DbType.Int64);


                var result = await DapperHelper.QueryAsync(
                    _vCDbContext,
                    "[usp_tbl_Transaction_10_PunishmentAwarded_4_GetById]",
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
                _logger.LogError(ex, "Failed to retrieve data for Allegation Of Misconduct Examined with ID: {Id}", id);

                await _logService.LogAsync(
                    $"Failed to retrieve data for Allegation Of Misconduct Examined with ID: {id}",
                    ex.StackTrace ?? "",
                    "Error"
                );

                return BaseResponseFactory.Error(ApplicationMessages.DataNotRetrivedError);
            }
        }
    }
}
