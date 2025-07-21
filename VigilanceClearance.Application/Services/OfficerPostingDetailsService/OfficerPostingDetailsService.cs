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
using VigilanceClearance.Application.Interfaces.OfficerPostingDetailsInterface;
using VigilanceClearance.Application.Services.VcPostSubService;
using VigilanceClearance.Infrastructure.Common.Helpers;
using VigilanceClearance.Infrastructure.Infrastructure.Persistence.DbContexts;

namespace VigilanceClearance.Application.Services.OfficerPostingDetailsService
{
    public class OfficerPostingDetailsService : IOfficerPostingDetails
    {
        private readonly VCDbContext _vCDbContext;
        private readonly ILogger<OfficerPostingDetailsService> _logger;
        private readonly ILogService _logService;
        public OfficerPostingDetailsService(VCDbContext vCDbContext, ILogger<OfficerPostingDetailsService> logger, ILogService logService)
        {
            _vCDbContext = vCDbContext;
            _logger = logger;
            _logService = logService;
        }



        public async Task<BaseResponseModel> OfficerPostingDetailsInsert(OfficerPostingDetailsInsert officerPostingDetailsInsert)
        {
            try
            {
                var parameters = new[]
                {
                    new SqlParameter("@MasterReferenceId", officerPostingDetailsInsert.MasterReferenceId),
                    new SqlParameter("@Vc_Officer_Id", officerPostingDetailsInsert.VcOfficerId),
                    new SqlParameter("@orgCode", officerPostingDetailsInsert.OrgCode),
                    new SqlParameter("@designation", officerPostingDetailsInsert.Designation),
                    new SqlParameter("@placeOfPosting", officerPostingDetailsInsert.PlaceOfPosting),
                    new SqlParameter("@orgMinistry", officerPostingDetailsInsert.OrgMinistry),
                    new SqlParameter("@fromDate", officerPostingDetailsInsert.FromDate),
                    new SqlParameter("@toDate", officerPostingDetailsInsert.ToDate),

                    new SqlParameter("@CreatedBy", officerPostingDetailsInsert.ActionBy),
                    new SqlParameter("@CreatedBy_SessionId", officerPostingDetailsInsert.ActionBy_SessionId),
                    new SqlParameter("@CreatedBy_IP", officerPostingDetailsInsert.ActionBy_IP),

                };
                var result = await _vCDbContext.Database.ExecuteSqlRawAsync(
                             @"EXEC usp_tbl_Transaction_7_OfficerPostingDetails_1_Insert 
                               @MasterReferenceId,
                               @Vc_Officer_Id, 
                               @orgCode, 
                               @designation, 
                               @placeOfPosting, 
                               @orgMinistry,
                               @fromDate,
                               @toDate,
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
                _logger.LogError(ex, "Failed to Insert usp_tbl_Transaction_7_OfficerPostingDetails_1_Insert ");

                await _logService.LogAsync(
                    $"Failed to Insert usp_tbl_Transaction_7_OfficerPostingDetails_1_Insert ",
                    ex.StackTrace ?? "",
                    "Error"
                );

                throw;
            }
        }
        public async Task<BaseResponseModel> OfficerPostingDetailsGetById(long? id)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@id", id, DbType.Int64);


                var result = await DapperHelper.QueryAsync(
                    _vCDbContext,
                    "[usp_tbl_Transaction_7_OfficerPostingDetails_4_GetById]",
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
                _logger.LogError(ex, "Failed to retrieve data for OfficerPostingDetails with ID: {Id}", id);

                await _logService.LogAsync(
                    $"Failed to retrieve data for OfficerPostingDetails with ID: {id}",
                    ex.StackTrace ?? "",
                    "Error"
                );

                return BaseResponseFactory.Error(ApplicationMessages.DataNotRetrivedError);
            }
        }

        public async Task<BaseResponseModel> OfficerPostingDetailsGetByOfficerId(long? id)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@OfficerID", id, DbType.Int64);


                var result = await DapperHelper.QueryAsync(
                    _vCDbContext,
                    "[usp_tbl_Transaction_7_OfficerPostingDetails_4_GetByOfficerId]",
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
                _logger.LogError(ex, "Failed to retrieve data for OfficerPostingDetails with OfficerID: {OfficerID}", id);

                await _logService.LogAsync(
                    $"Failed to retrieve data for OfficerPostingDetails with OfficerID: {id}",
                    ex.StackTrace ?? "",
                    "Error"
                );

                return BaseResponseFactory.Error(ApplicationMessages.DataNotRetrivedError);
            }
        }

        public async Task<BaseResponseModel> GetOfficerPostingDetailsByPostingId(long id)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@ID", id, DbType.Int64);


                var result = await DapperHelper.QueryAsync(
                    _vCDbContext,
                    "[usp_GetOfficerPostingDetailsByPostingId]",
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
                _logger.LogError(ex, "Failed to retrieve data for OfficerPostingDetails with OfficerID: {OfficerID}", id);

                await _logService.LogAsync(
                    $"Failed to retrieve data for OfficerPostingDetails with OfficerID: {id}",
                    ex.StackTrace ?? "",
                    "Error"
                );

                return BaseResponseFactory.Error(ApplicationMessages.DataNotRetrivedError);
            }

        }



    }
}
