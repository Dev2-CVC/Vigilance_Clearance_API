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
using VigilanceClearance.Application.Interfaces.ActionContemplatedAgainstTheOfficer_12Interface;
using VigilanceClearance.Infrastructure.Common.Helpers;
using VigilanceClearance.Infrastructure.Infrastructure.Persistence.DbContexts;

namespace VigilanceClearance.Application.Services.ActionContemplatedAgainstTheOfficer_12Service
{
    public class ActionContemplatedAgainstTheOfficer_12Service : IActionContemplatedAgainstTheOfficer_12
    {
        private readonly VCDbContext _vCDbContext;
        private readonly ILogger<ActionContemplatedAgainstTheOfficer_12Service> _logger;
        private readonly ILogService _logService;
        public ActionContemplatedAgainstTheOfficer_12Service(VCDbContext vCDbContext, ILogger<ActionContemplatedAgainstTheOfficer_12Service> logger, ILogService logService)
        {
            _vCDbContext = vCDbContext;
            _logger = logger;
            _logService = logService;
        }


        public async Task<BaseResponseModel> insertActionContemplatedAgainstTheOfficer(ActionContemplatedAgainstTheOfficer actionContemplatedAgainstTheOfficerMode)
        {
            try
            {
                var parameters = new[]
                {
                      new SqlParameter("@officerId", actionContemplatedAgainstTheOfficerMode.officerId),
                      new SqlParameter("@whether_CaseContemplated", actionContemplatedAgainstTheOfficerMode.whether_CaseContemplated),
                      new SqlParameter("@detailsOfTheCase", actionContemplatedAgainstTheOfficerMode.detailsOfTheCase),
                      new SqlParameter("@presentStatusOftheCase", actionContemplatedAgainstTheOfficerMode.presentStatusOftheCase),
                      new SqlParameter("@CreatedBy", actionContemplatedAgainstTheOfficerMode.ActionBy),
                      new SqlParameter("@CreatedBy_SessionId", actionContemplatedAgainstTheOfficerMode.ActionBy_SessionId),
                      new SqlParameter("@CreatedBy_IP", actionContemplatedAgainstTheOfficerMode.ActionBy_IP)
                };

                var result = await _vCDbContext.Database.ExecuteSqlRawAsync(
                              @"EXEC usp_tbl_Transaction_12_ActionContemplatedAgainstTheOfficerAsOnDate_1_Insert 
                               @officerId, 
                               @whether_CaseContemplated, 
                               @detailsOfTheCase, 
                               @presentStatusOftheCase,                                                              
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
                _logger.LogError(ex, "Failed to Insert usp_tbl_Transaction_12_ActionContemplatedAgainstTheOfficerAsOnDate_1_Insert ");

                await _logService.LogAsync(
                    $"Failed to Insert usp_tbl_Transaction_12_ActionContemplatedAgainstTheOfficerAsOnDate_1_Insert ",
                    ex.StackTrace ?? "",
                    "Error"
                );

                return BaseResponseFactory.Error();
            }
        }


        public async Task<BaseResponseModel> GetActionContemplatedAgainstTheOfficelistById(long? id)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@id", id, DbType.Int64);


                var result = await DapperHelper.QueryAsync(
                    _vCDbContext,
                    "[usp_tbl_Transaction_12_ActionContemplatedAgainstTheOfficerAsOnDate_4_GetById]",
                    parameters
                );

                //var entity = result.FirstOrDefault();
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
