using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using VigilanceClearance.Application.Common.Helpers;
using VigilanceClearance.Application.DTOs.Requests;
using VigilanceClearance.Application.DTOs.Responses;
using VigilanceClearance.Application.Interfaces;
using VigilanceClearance.Application.Interfaces.IntegrityAgreedOrDoubtfuliNTERFACE;
using VigilanceClearance.Application.Interfaces.OfficerDetailsInterface;
using VigilanceClearance.Application.Services.VcPostSubService;
using VigilanceClearance.Infrastructure.Common.Helpers;
using VigilanceClearance.Infrastructure.Infrastructure.Persistence.DbContexts;

namespace VigilanceClearance.Application.Services.IntegrityAgreedOrDoubtfulService
{
    public class IntegrityAgreedOrDoubtfulService : IIntegrityAgreedOrDoubtful
    {
        public readonly VCDbContext _vCDbContext;
        private readonly ILogger<IntegrityAgreedOrDoubtfulService> _logger;
        private readonly ILogService _logService;
        public IntegrityAgreedOrDoubtfulService(VCDbContext vCDbContext, ILogger<IntegrityAgreedOrDoubtfulService> logger, ILogService logService)
        {
            _vCDbContext = vCDbContext;
            _logger = logger;
            _logService = logService;
        }

        public async Task<BaseResponseModel> IntegrityAgreedOrDoubtfulGetByOfficerID(long? id)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Officerid", id, DbType.Int64);


                var result = await DapperHelper.QueryAsync(
                    _vCDbContext,
                    "[usp_tbl_Transaction_8_IntegrityAgreedOrDoubtful_4_GetBy_OfficerId]",
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
                _logger.LogError(ex, "Failed to retrieve data for IntegrityAgreedOrDoubtful with OfficerID: {Id}", id);

                await _logService.LogAsync(
                    $"Failed to retrieve data for IntegrityAgreedOrDoubtful with OfficerID: {id}",
                    ex.StackTrace ?? "",
                    "Error"
                );

                return BaseResponseFactory.Error(ApplicationMessages.DataNotRetrivedError);
            }
        }
        public async Task<BaseResponseModel> IntegrityAgreedOrDoubtfulInsert(IntegrityAgreedOrDoubtfulInsert integrityAgreedOrDoubtfulInsert)
        {
            try
            {
                var parameters = new[]
                {
                    new SqlParameter("@MasterReferenceId", integrityAgreedOrDoubtfulInsert.MasterReferenceId),
            new SqlParameter("@officerId", integrityAgreedOrDoubtfulInsert.OfficerId),
            new SqlParameter("@enteredInTheList", integrityAgreedOrDoubtfulInsert.EnteredInTheList),
             new SqlParameter("@dateOfEntryInTheList", integrityAgreedOrDoubtfulInsert.DateOfEntryInTheList),
              new SqlParameter("@removedFromTheList", integrityAgreedOrDoubtfulInsert.RemovedFromTheList),
               new SqlParameter("@DateOfRemovalFromTheList", integrityAgreedOrDoubtfulInsert.DateOfRemovalFromTheList),
                new SqlParameter("@CreatedBy", integrityAgreedOrDoubtfulInsert.ActionBy),
                   new SqlParameter("@CreatedOn", integrityAgreedOrDoubtfulInsert.ActionOn),
                 new SqlParameter("@CreatedBy_SessionId", integrityAgreedOrDoubtfulInsert.ActionBy_SessionId),
                new SqlParameter("@CreatedBy_IP", integrityAgreedOrDoubtfulInsert.ActionBy_IP)                   
                };
               
                var result = await _vCDbContext.Database.ExecuteSqlRawAsync(
      @"EXEC usp_tbl_Transaction_8_IntegrityAgreedOrDoubtful_1_Insert 
          @MasterReferenceId,
        @officerId, 
        @enteredInTheList, 
        @dateOfEntryInTheList, 
        @removedFromTheList, 
        @DateOfRemovalFromTheList, 
        @CreatedBy, 
        @CreatedOn, 
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
                _logger.LogError(ex, "Failed to Insert usp_tbl_Transaction_8_IntegrityAgreedOrDoubtful_1_Insert ");

                await _logService.LogAsync(
                    $"Failed to Insert usp_tbl_Transaction_8_IntegrityAgreedOrDoubtful_1_Insert ",
                    ex.StackTrace ?? "",
                    "Error"
                );

                return BaseResponseFactory.Error();
            }
        }

    }
}
