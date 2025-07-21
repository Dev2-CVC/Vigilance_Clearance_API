using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Data;
using VigilanceClearance.Application.Common.Helpers;
using VigilanceClearance.Application.DTOs.Requests;
using VigilanceClearance.Application.DTOs.Responses;
using VigilanceClearance.Application.Interfaces;
using VigilanceClearance.Infrastructure.Common.Helpers;
using VigilanceClearance.Infrastructure.Infrastructure.Persistence.DbContexts;

namespace VigilanceClearance.Application.Services.Coord2_DealingHand
{
    
    public class Coord2_DealingHandService: ICoord2_DealingHand
    {
        private readonly VCDbContext _vCDbContext;
        private readonly ILogger<Coord2_DealingHandService> _logger;
        private readonly ILogService _logService;

        public Coord2_DealingHandService(VCDbContext vCDbContext, ILogger<Coord2_DealingHandService> logger, ILogService logService)
        {
            _vCDbContext = vCDbContext;
            _logger = logger;
            _logService = logService;
        }

        public async Task<BaseResponseModel> OfficerDetailWithPostingDetails(long masterReferenceID)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@MasterReferenceID", masterReferenceID, DbType.Int64);


                var result = await DapperHelper.QueryAsync(
                    _vCDbContext,
                    "[usp_GetOfficerDetailsWithPostings_ByMasterReferenceID]",
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
                _logger.LogError(ex, "Failed to retrieve data for OfficerDetailWithPostingDetails with ID: {Id}", masterReferenceID);

                await _logService.LogAsync(
                    $"Failed to retrieve data for OfficerDetailWithPostingDetails with ID: {masterReferenceID}",
                    ex.StackTrace ?? "",
                    "Error"
                );

                return BaseResponseFactory.Error(ApplicationMessages.DataNotRetrivedError);
            }
        }

        public async Task<BaseResponseModel> ForwardProposalTo_BranchesAndMinistry(ForwardProposalTo_BranchesAndMinistryModel forwardProposalTo_BranchesAndMinistryModel)
        {
            try
            {
                var parameters = new[]
                {
                    new SqlParameter("@MasterReferenceId", forwardProposalTo_BranchesAndMinistryModel.MasterReferenceId),
                    new SqlParameter("@OfficerId", forwardProposalTo_BranchesAndMinistryModel.OfficerId),
                    

                    //new SqlParameter("@CreatedBy", officerPostingDetailsInsert.ActionBy),
                    //new SqlParameter("@CreatedBy_SessionId", officerPostingDetailsInsert.ActionBy_SessionId),
                    //new SqlParameter("@CreatedBy_IP", officerPostingDetailsInsert.ActionBy_IP),

                };
                var result = await _vCDbContext.Database.ExecuteSqlRawAsync(
                             @"EXEC usp_ForwardProposalTo_BranchesAndMinistry 
                               @MasterReferenceId,
                               @OfficerId 
                               
                             ",
                parameters);

                if (result > 0)
                {
                    BaseResponseModel responsemodel = new BaseResponseModel()
                    {
                        IsSuccess = true,
                        Message = "Record Inserted Successfully"
                    };
                    return responsemodel;
                }
                else
                {
                    BaseResponseModel responsemodel = new BaseResponseModel()
                    {
                        IsSuccess = false,
                        Message = "Record Not Inserted Successfully"
                    };

                    return responsemodel;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to Insert usp_ForwardProposalTo_BranchesAndMinistry ");

                await _logService.LogAsync(
                    $"Failed to Insert usp_ForwardProposalTo_BranchesAndMinistry ",
                    ex.StackTrace ?? "",
                    "Error"
                );
                throw;
            }
        }


    }
}
