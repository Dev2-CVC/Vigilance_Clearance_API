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
using VigilanceClearance.Application.Interfaces.DealingHand;
using VigilanceClearance.Application.Services.Coord2_DealingHand;
using VigilanceClearance.Infrastructure.Common.Helpers;
using VigilanceClearance.Infrastructure.Infrastructure.Persistence.DbContexts;

namespace VigilanceClearance.Application.Services.DealingHand
{
    public class DealingHandService : IDealingHand
    {
        private readonly VCDbContext _vCDbContext;
        private readonly ILogger<Coord2_DealingHandService> _logger;
        private readonly ILogService _logService;

        public DealingHandService(VCDbContext vCDbContext, ILogger<Coord2_DealingHandService> logger, ILogService logService)
        {
            _vCDbContext = vCDbContext;
            _logger = logger;
            _logService = logService;
        }

        public async Task<BaseResponseModel> GetPendingListFor_BranchDH(string Branch)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@section", Branch);

                var result = await DapperHelper.QueryAsync(
                    _vCDbContext,
                    "[usp_GetPendingListFor_BranchDH]",
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
                _logger.LogError(ex, "Failed to retrieve data for Get_Pending_ListFor_BranchDH with ID: {Id}", Branch);

                await _logService.LogAsync(
                    $"Failed to retrieve data for Get_Pending_ListFor_BranchDH with ID: {Branch}",
                    ex.StackTrace ?? "",
                    "Error"
                );

                return BaseResponseFactory.Error(ApplicationMessages.DataNotRetrivedError);
            }
        }
        public async Task<BaseResponseModel> OfficerDetailsForCVCUsers_List(int masterRefid, string Branch)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@MasterReferenceId", masterRefid);
                parameters.Add("@section", Branch);

                var result = await DapperHelper.QueryAsync(
                    _vCDbContext,
                    "usp_GetOfficersDetailsFor_CVC_Users",
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
                _logger.LogError(ex, "Failed to retrieve data for Officer_Details_For_CVCUsers_List: {Id}", Branch);

                await _logService.LogAsync(
                    $"Failed to retrieve data for Officer_Details_For_CVCUsers_List with ID: {Branch}",
                    ex.StackTrace ?? "",
                    "Error"
                );

                return BaseResponseFactory.Error(ApplicationMessages.DataNotRetrivedError);
            }
        }
        public async Task<BaseResponseModel> VigBranchCommentsInsert(VigBranchCommentsInsert vigBranchCommentsobj)
        {
            try
            {
                var parameters = new[]
                {
                    new SqlParameter("@MasterReferenceID", (object?)vigBranchCommentsobj.MasterReferenceID ?? DBNull.Value),
                    new SqlParameter("@officerID", (object?)vigBranchCommentsobj.officerID ?? DBNull.Value),
                    new SqlParameter("@AdverseOrNothingAdverse", (object?)vigBranchCommentsobj.AdverseOrNothingAdverse ?? DBNull.Value),
                    new SqlParameter("@AdverseRemarks", (object?)vigBranchCommentsobj.AdverseRemarks?? DBNull.Value),
                    new SqlParameter("@CreatedById", (object?)vigBranchCommentsobj.CreatedById ?? DBNull.Value)
                };
                var result = await _vCDbContext.Database.ExecuteSqlRawAsync("EXEC usp_Insert_VigBranch_Comments " +
                    "@MasterReferenceID, @officerID, @AdverseOrNothingAdverse, @AdverseRemarks, @CreatedById", parameters);
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
                _logger.LogError(ex, "Failed to Insert usp_Insert_VigBranch_Comments ");

                await _logService.LogAsync(
                    $"Failed to Insert usp_Insert_VigBranch_Comments ",
                    ex.StackTrace ?? "",
                    "Error"
                );
                return BaseResponseFactory.Error(ApplicationMessages.RecordNotInsertedError);
            }
        }
        public async Task<BaseResponseModel> GetVigBranchComments(long masterRefid, long Officerid)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@MasterReferenceID", masterRefid);
                parameters.Add("@officerID", Officerid);

                var result = await DapperHelper.QueryAsync(
                    _vCDbContext,
                    "usp_Get_VigBranch_Comments",
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
                _logger.LogError(ex, "Failed to retrieve data for GetVigBranchComments: {Id}", masterRefid, Officerid);

                await _logService.LogAsync(
                    $"Failed to retrieve data for GetVigBranchComments with ID: {masterRefid}",
                    ex.StackTrace ?? "",
                    "Error"
                );

                return BaseResponseFactory.Error(ApplicationMessages.DataNotRetrivedError);
            }
        }
    }
}
