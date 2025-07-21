using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Data;
using VigilanceClearance.Application.Common.Helpers;
using VigilanceClearance.Application.DTOs.Requests;
using VigilanceClearance.Application.DTOs.Responses;
using VigilanceClearance.Application.Interfaces;
using VigilanceClearance.Application.Interfaces.VcReferenceReceivedForInterface;
using VigilanceClearance.Infrastructure.Common.Helpers;
using VigilanceClearance.Infrastructure.Infrastructure.Persistence.DbContexts;
using VigilanceClearance.Infrastructure.Infrastructure.Persistence.Models;

namespace VigilanceClearance.Application.Services.VcReferenceReceivedFor
{
    public class VcReferenceReceivedFor : IVcReferenceReceivedFor
    {
        private readonly VCDbContext _vCDbContext;
        private readonly ILogger<VcReferenceReceivedFor> _logger;
        private readonly ILogService _logService;
        public VcReferenceReceivedFor(VCDbContext vCDbContext, ILogger<VcReferenceReceivedFor> _logger, ILogService _logService)
        {
             _vCDbContext = vCDbContext;
            this._logger = _logger;
            this._logService = _logService;
        }

        public async Task<BaseResponseModel> VcReferenceReceivedForGetById(long? id, string? userName)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@id", id, DbType.Int64);
                parameters.Add("@UserName", userName, DbType.String);

                var result = await DapperHelper.QueryAsync(
                    _vCDbContext, 
                    "usp_tbl_Master_Vc_ReferenceReceivedFor_4_GetById",
                    parameters
                );

                var entity = result;

                if (entity == null)
                {
                    return BaseResponseFactory.NotFound();
                }

                return BaseResponseFactory.Success(entity,ApplicationMessages.DataRetrived );
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to retrieve data for ReferenceReceivedFor with ID: {Id}, User: {UserName}", id, userName);

                await _logService.LogAsync(
                    $"Failed to retrieve data for ReferenceReceivedFor with ID: {id}, User: {userName}",
                    ex.StackTrace ?? "",
                    "Error"
                );

                return BaseResponseFactory.Error(ApplicationMessages.DataNotRetrivedError);
            }
        }
        public async Task<BaseResponseModel> VcReferenceReceivedDetailsGetById(long? id)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@id", id, DbType.Int64);
              

                var result = await DapperHelper.QueryAsync(
                    _vCDbContext,
                    "usp_tbl_Master_Vc_ReferenceReceivedForDetails_4_GetById",
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
                _logger.LogError(ex, "Failed to retrieve data for ReferenceReceivedFor with ID: {Id}", id);

                await _logService.LogAsync(
                    $"Failed to retrieve data for ReferenceReceivedFor with ID: {id}",
                    ex.StackTrace ?? "",
                    "Error"
                );

                return BaseResponseFactory.Error(ApplicationMessages.DataNotRetrivedError);
            }
        }
        public async Task<BaseResponseModel> VcReferenceReceivedDetailsGetAll()
        {
            try
            {
                var result = await DapperHelper.QueryAsync(
                    _vCDbContext,
                    "usp_tbl_Master_Vc_ReferenceReceivedFor_5_GetAll", null
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
                _logger.LogError(ex, "Failed to retrieve data for VcReferenceReceivedDetailsGetAll");

                await _logService.LogAsync(
                    $"Failed to retrieve data for VcReferenceReceivedDetailsGetAll ",
                    ex.StackTrace ?? "",
                    "Error"
                );

                return BaseResponseFactory.Error(ApplicationMessages.DataNotRetrivedError);
            }
        }
        public async Task<BaseResponseModel> VcReferenceReceivedForInsert(TblMasterVcReferenceReceivedFor model)
        {
            try
            {
              
                await _vCDbContext.TblMasterVcReferenceReceivedFor.AddAsync(model);

                
                await _vCDbContext.SaveChangesAsync();

                return BaseResponseFactory.Success();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while inserting VcReferenceReceivedFor.");

                await _logService.LogAsync(
                    "Error while inserting VcReferenceReceivedFor",
                    ex.StackTrace ?? "",
                    "Error"
                );

                return BaseResponseFactory.Error(ApplicationMessages.RecordNotInsertedError);
            }
        }


        public async Task<BaseResponseModel> ReferenceReceivedForInsert(ReferenceReceivedForModel modelobj)
        {
            try
            {
                var parameters = new[]
                {
                    new SqlParameter("@ReferenceReceivedFor", modelobj.ReferenceReceivedFor),
                    new SqlParameter("@ReferenceReceivedFrom", modelobj.ReferenceReceivedFrom),
                    new SqlParameter("@ReferenceReceivedFromCode", modelobj.ReferenceReceivedFromCode),
                    new SqlParameter("@selectionForThePostCategory", modelobj.SelectionForThePostCategory),
                    new SqlParameter("@selectionForThePostSubCategory", modelobj.SelectionForThePostSubCategory),
                    new SqlParameter("@OrgCode", modelobj.OrgCode),
                    new SqlParameter("@OrgName", modelobj.OrgName),
                    new SqlParameter("@MinCode", modelobj.MinCode),
                    new SqlParameter("@MinDesc", modelobj.MinDesc),
                    new SqlParameter("@PendingWith", modelobj.PendingWith),
                    new SqlParameter("@ReferenceID", modelobj.ReferenceID),
                    new SqlParameter("@CVC_ReferenceID_FileNo", modelobj.CVC_ReferenceID_FileNo),
                    new SqlParameter("@CreatedBy", modelobj.ActionBy),
                    new SqlParameter("@CreatedBy_SessionId", modelobj.ActionBy_SessionId),
                    new SqlParameter("@CreatedBy_IP", modelobj.ActionBy_IP),

                };
                var result = await _vCDbContext.Database.ExecuteSqlRawAsync(
                             @"EXEC usp_tbl_Master_Vc_ReferenceReceivedFor_1_Insert 
                               @ReferenceReceivedFor, 
                               @ReferenceReceivedFrom, 
                               @ReferenceReceivedFromCode, 
                               @selectionForThePostCategory, 
                               @selectionForThePostSubCategory,
                               @OrgCode,
                               @OrgName,
                               @MinCode,
                               @MinDesc,
                               @PendingWith,
                               @ReferenceID,
                               @CVC_ReferenceID_FileNo,
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
                _logger.LogError(ex, "Failed to Insert usp_tbl_Master_Vc_ReferenceReceivedFor_1_Insert ");

                await _logService.LogAsync(
                    $"Failed to Insert usp_tbl_Master_Vc_ReferenceReceivedFor_1_Insert ",
                    ex.StackTrace ?? "",
                    "Error"
                );

                throw;
            }
        }

        public async Task<BaseResponseModel> ReferenceFromPESBUpdate(ReferenceFromPESBUpdate modelobj)
        {
            try
            {
                var param = new[]
                {
             //new SqlParameter("@MainReferenceId",
             //modelobj.MainReferenceID.HasValue ? modelobj.MainReferenceID : (object)DBNull.Value),
             new SqlParameter("@MainReferenceId", modelobj.MainReferenceID),


            new SqlParameter("@PendingWith",modelobj.PendingWith ?? (object)DBNull.Value),
            new SqlParameter("@UpdateBy",modelobj.UpdatedBy ?? (object)DBNull.Value),
            new SqlParameter("@UpdatedBy_SessionId",modelobj.UpdatedBy_SessionId ?? (object)DBNull.Value),
            new SqlParameter("@UpdatedBy_IP",modelobj.UpdatedBy_IP ?? (object)DBNull.Value),

       };
                var result = await _vCDbContext.Database.ExecuteSqlRawAsync(
                     "EXEC usp_UpdateReferenceFromPESB @MainReferenceId,@PendingWith,@UpdateBy,@UpdatedBy_SessionId,@UpdatedBy_IP", param
                                   );

                if (result > 0)
                {
                    return BaseResponseFactory.Success(ApplicationMessages.UpdateSuccess);
                }
                else
                {
                    BaseResponseModel responseModel = new BaseResponseModel()
                    {
                        IsSuccess = false,
                        Message = "Record Not Inserted Successfully"
                    };
                    return BaseResponseFactory.UpdateFailed();
                }


            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to Update usp_UpdateReferenceFromPESB ");

                await _logService.LogAsync(
                    $"Failed to Update usp_UpdateReferenceFromPESB ",
                    ex.StackTrace ?? "",
                    "Error"
                );

                return BaseResponseFactory.Error(ApplicationMessages.RecordUpdatedError);
            }
        }
        public async Task<BaseResponseModel> VcReferenceReceivedDetailsUpdateById(VcReferenceReceivedForUpdate model)
        {




            try
            {
                var id = model.id;
                var username = model.UpdateBy;
                var pendingwith = model.PendingWith;
                var UpdatedBy_SessionId = model.UpdatedBy_SessionId;
                var UpdatedByIp = model.UpdatedBy_IP;

                using var connection = _vCDbContext.Database.GetDbConnection();
                if (connection.State != ConnectionState.Open)
                    connection.Open();

                var parameters = new DynamicParameters();
                parameters.Add("@MainReferenceId", id);
                parameters.Add("@PendingWith", pendingwith);
                parameters.Add("@UpdateBy", username);
                parameters.Add("@UpdatedBy_SessionId", UpdatedBy_SessionId);
                parameters.Add("@UpdatedBy_IP", UpdatedByIp);

                await connection.ExecuteAsync(
                    "usp_UpdateReferenceFromPESB",
                    parameters,
                    commandType: CommandType.StoredProcedure);

                return BaseResponseFactory.Success(ApplicationMessages.RecordUpdated);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while calling stored procedure for updating VcReference.");
                return BaseResponseFactory.Error(ApplicationMessages.RecordNotUpdated);
            }
        }
    }
}
