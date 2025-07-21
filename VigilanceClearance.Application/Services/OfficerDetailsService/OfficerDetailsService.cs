using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using VigilanceClearance.Application.Common.Helpers;
using VigilanceClearance.Application.DTOs.Requests;
using VigilanceClearance.Application.DTOs.Responses;
using VigilanceClearance.Application.Interfaces;
using VigilanceClearance.Application.Interfaces.OfficerDetailsInterface;
using VigilanceClearance.Infrastructure.Common.Helpers;
using VigilanceClearance.Infrastructure.Infrastructure.Persistence.DbContexts;

namespace VigilanceClearance.Application.Services.OfficerDetailsService
{
    public class OfficerDetailsService : IOfficerDetails
    {
        private readonly VCDbContext _vCDbContext;
        private readonly ILogger<OfficerDetailsService> _logger;
        private readonly ILogService _logService;
        public OfficerDetailsService(VCDbContext vCDbContext, ILogger<OfficerDetailsService> logger, ILogService logService)
        {
            _vCDbContext = vCDbContext;
            _logger = logger;
            _logService = logService;
        }
        public async Task<BaseResponseModel> OfficerDetailsGetById(long? id)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@id", id, DbType.Int64);


                var result = await DapperHelper.QueryAsync(
                    _vCDbContext,
                    "[usp_tbl_Master_Vc_1_OfficerDetails_4_GetById]",
                    parameters
                );

                var entity = result.FirstOrDefault();

                if (entity == null)
                {
                    return BaseResponseFactory.NotFound();
                }

                return BaseResponseFactory.Success(entity, ApplicationMessages.DataRetrived);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to retrieve data for OfficerDetails with ID: {Id}", id);

                await _logService.LogAsync(
                    $"Failed to retrieve data for OfficerDetails with ID: {id}",
                    ex.StackTrace ?? "",
                    "Error"
                );

                return BaseResponseFactory.Error(ApplicationMessages.DataNotRetrivedError);
            }
        }
        public async Task<BaseResponseModel> OfficerDetailsGetByMasterReferenceID(long? id)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@MasterReferenceId", id, DbType.Int64);


                var result = await DapperHelper.QueryAsync(
                    _vCDbContext,
                    "[usp_tbl_Master_Vc_1_OfficerDetails_4_GetByMasterReferenceID]",
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
                _logger.LogError(ex, "Failed to retrieve data for OfficerDetails with ID: {Id}", id);

                await _logService.LogAsync(
                    $"Failed to retrieve data for OfficerDetails with ID: {id}",
                    ex.StackTrace ?? "",
                    "Error"
                );

                return BaseResponseFactory.Error(ApplicationMessages.DataNotRetrivedError);
            }
        }
        public async Task<BaseResponseModel> OfficerDetailsInsert(OfficerDetailsInsert officerDetailsInsert)
        {
            try
            {
                var parameters = new[]
                {
    //       new SqlParameter("@selectionForThePostCategory", officerDetailsInsert.SelectionForThePostCategory),
    //new SqlParameter("@selectionForThePostSubCategory", officerDetailsInsert.SelectionForThePostSubCategory),
    new SqlParameter("@MasterReferenceID", officerDetailsInsert.MasterReferenceID),
    //new SqlParameter("@ReferenceReceivedFor", officerDetailsInsert.ReferenceReceivedFor),
    //new SqlParameter("@othersRemarks", officerDetailsInsert.OthersRemarks),
    //new SqlParameter("@orgCode", officerDetailsInsert.OrgCode),
    new SqlParameter("@Officer_Name", officerDetailsInsert.Officer_Name),
    new SqlParameter("@Officer_FatherName", officerDetailsInsert.Officer_FatherName),
    new SqlParameter("@Officer_DateOfBirth", officerDetailsInsert.Officer_DateOfBirth),
    new SqlParameter("@Officer_RetirementDate", officerDetailsInsert.Officer_RetirementDate),
    new SqlParameter("@Officer_ServiceEntryDate", officerDetailsInsert.Officer_ServiceEntryDate),
    new SqlParameter("@Officer_Service", officerDetailsInsert.Officer_Service),
    new SqlParameter("@Officer_Other_Service", officerDetailsInsert.Officer_Other_Service),
    new SqlParameter("@Officer_Batch_Year", officerDetailsInsert.Officer_Batch_Year),
    new SqlParameter("@Officer_Cadre", officerDetailsInsert.Officer_Cadre),
    // new SqlParameter("@OfficerPostingDetails_7", officerDetailsInsert.OfficerPostingDetails_7),
    //new SqlParameter("@IntegrityAgreedOrDoubtful_8", officerDetailsInsert.IntegrityAgreedOrDoubtful_8),
    //new SqlParameter("@AllegationOfMisconductExamined_9", officerDetailsInsert.AllegationOfMisconductExamined_9),
    //new SqlParameter("@PunishmentAwarded_10", officerDetailsInsert.PunishmentAwarded_10),
    //new SqlParameter("@DisciplinaryCriminalProceedings_11", officerDetailsInsert.DisciplinaryCriminalProceedings_11),
    //new SqlParameter("@ActionContemplatedAgainstTheOfficerAsOnDate_12", officerDetailsInsert.ActionContemplatedAgainstTheOfficerAsOnDate_12),
    //new SqlParameter("@ComplaintWithVigilanceAnglePending_13", officerDetailsInsert.ComplaintWithVigilanceAnglePending_13),
    new SqlParameter("@CreatedBy", officerDetailsInsert.CreatedBy),
    //new SqlParameter("@CreatedOn", officerDetailsInsert.CreatedOn),
    new SqlParameter("@CreatedBy_SessionId", officerDetailsInsert.CreatedBy_SessionId),
    new SqlParameter("@CreatedBy_IP", officerDetailsInsert.CreatedBy_IP),
    //new SqlParameter("@UpdateBy", officerDetailsInsert.UpdateBy),
    //new SqlParameter("@UpdatedOn", officerDetailsInsert.UpdatedOn),
    //new SqlParameter("@UpdatedBy_SessionId", officerDetailsInsert.UpdatedBy_SessionId),
    //new SqlParameter("@UpdatedBy_IP", officerDetailsInsert.UpdatedBy_IP)

        };
                var result = await _vCDbContext.Database.ExecuteSqlRawAsync(
               @"EXEC [usp_tbl_Master_Vc_1_OfficerDetails_1_Insert] 
         
                  @MasterReferenceID, 
                  @Officer_Name, 
                  @Officer_FatherName, 
                  @Officer_DateOfBirth, 
                  @Officer_RetirementDate, 
                  @Officer_ServiceEntryDate, 
                  @Officer_Service, 
                  @Officer_Other_Service,
                  @Officer_Batch_Year, 
                  @Officer_Cadre, 
                  @CreatedBy, 
                  @CreatedBy_SessionId, 
                  @CreatedBy_IP",
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
                _logger.LogError(ex, "Failed to Insert usp_tbl_Master_Vc_1_OfficerDetails_Insert ");

                await _logService.LogAsync(
                    $"Failed to Insert usp_tbl_Master_Vc_1_OfficerDetails_Insert ",
                    ex.StackTrace ?? "",
                    "Error"
                );

                throw;
            }
        }


        #region Added as on date 16_07_2025


        public async Task<BaseResponseModel> OfficerDetails_GetByOfficerId_ForMinistry(long? OfficerId)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@OfficerId", OfficerId, DbType.Int64);

                var result = await DapperHelper.QueryAsync(
                    _vCDbContext,
                    "[usp_tbl_Master_Vc_1_OfficerDetails_4_GetByOfficerId_ForMinistry]",
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
                _logger.LogError(ex, "Failed to retrieve data for OfficerDetails with ID: {Id}", OfficerId);

                await _logService.LogAsync(
                    $"Failed to retrieve data for OfficerDetails with ID: {OfficerId}",
                    ex.StackTrace ?? "",
                    "Error"
                );

                return BaseResponseFactory.Error(ApplicationMessages.DataNotRetrivedError);
            }
        }


        #endregion




    }
}
