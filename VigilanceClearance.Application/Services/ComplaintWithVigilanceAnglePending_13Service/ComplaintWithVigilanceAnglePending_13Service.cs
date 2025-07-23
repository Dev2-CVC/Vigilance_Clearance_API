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
using VigilanceClearance.Application.Interfaces.ComplaintWithVigilanceAnglePending_13Interface;
using VigilanceClearance.Infrastructure.Common.Helpers;
using VigilanceClearance.Infrastructure.Infrastructure.Persistence.DbContexts;

namespace VigilanceClearance.Application.Services.ComplaintWithVigilanceAnglePending_13Service
{
    public class ComplaintWithVigilanceAnglePending_13Service : IComplaintWithVigilanceAnglePending
    {
        private readonly VCDbContext _vCDbContext;
        private readonly ILogger<ComplaintWithVigilanceAnglePending_13Service> _logger;
        private readonly ILogService _logService;
        public ComplaintWithVigilanceAnglePending_13Service(VCDbContext vCDbContext, ILogger<ComplaintWithVigilanceAnglePending_13Service> logger, ILogService logService)
        {
            _vCDbContext = vCDbContext;
            _logger = logger;
            _logService = logService;
        }


        public async Task<BaseResponseModel> insertComplaintWithVigilanceAnglePending(ComplaintWithVigilanceAnglePending complaintWithVigilanceAnglePendingModel)
        {
            try
            {
                var parameters = new[]
                {
                     new SqlParameter("@MasterReferenceId", complaintWithVigilanceAnglePendingModel.MasterReferenceId),
                      new SqlParameter("@officerId", complaintWithVigilanceAnglePendingModel.officerId),
                      new SqlParameter("@whether_vigilanceAngelPending", complaintWithVigilanceAnglePendingModel.whether_vigilanceAnglePending),
                      new SqlParameter("@detailsOfTheCase", complaintWithVigilanceAnglePendingModel.detailsOfTheCase),
                      new SqlParameter("@presentStatusOftheCase", complaintWithVigilanceAnglePendingModel.presentStatusOftheCase),
                      new SqlParameter("@addtionalRemarks", complaintWithVigilanceAnglePendingModel.additionalRemarks),
                      new SqlParameter("@CreatedBy", complaintWithVigilanceAnglePendingModel.ActionBy),
                      new SqlParameter("@CreatedBy_SessionId", complaintWithVigilanceAnglePendingModel.ActionBy_SessionId),
                      new SqlParameter("@CreatedBy_IP", complaintWithVigilanceAnglePendingModel.ActionBy_IP)
                };

                var result = await _vCDbContext.Database.ExecuteSqlRawAsync(
                              @"EXEC usp_tbl_Transaction_13_ComplaintWithVigilanceAnglePending_1_Insert
                              @MasterReferenceId,
                               @officerId, 
                               @whether_vigilanceAngelPending, 
                               @detailsOfTheCase, 
                               @presentStatusOftheCase, 
                               @addtionalRemarks,
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


        public async Task<BaseResponseModel> GetComplaintWithVigilanceAnglePendinglistById(long? id)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@id", id, DbType.Int64);


                var result = await DapperHelper.QueryAsync(
                    _vCDbContext,
                    "[usp_tbl_Transaction_13_ComplaintWithVigilanceAnglePending_4_GetById]",
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
