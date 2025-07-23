using System;
using System.Collections.Generic;
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
using VigilanceClearance.Infrastructure.Common.Helpers;
using VigilanceClearance.Infrastructure.Infrastructure.Persistence.DbContexts;
using VigilanceClearance.Application.Interfaces.AllegationOfMisconductExamined_9Interface;

namespace VigilanceClearance.Application.Services.AllegationOfMisconductExamined_9Service
{
    public class AllegationOfMisconductExamined_9Service : IAllegationOfMisconductExamined_9
    {
        private readonly VCDbContext _vCDbContext;
        private readonly ILogger<AllegationOfMisconductExamined_9Service> _logger;
        private readonly ILogService _logService;
        public AllegationOfMisconductExamined_9Service(VCDbContext vCDbContext, ILogger<AllegationOfMisconductExamined_9Service> logger, ILogService logService)
        {
            _vCDbContext = vCDbContext;
            _logger = logger;
            _logService = logService;
        }


        public async Task<BaseResponseModel> AllegationOfMisconductExamined_9GetById(long? id)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@id", id, DbType.Int64);


                var result = await DapperHelper.QueryAsync(
                    _vCDbContext,
                    "[usp_tbl_Transaction_9_AllegationOfMisconductExamined_4_GetById]",
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


        public async Task<BaseResponseModel> insertAllegationOfMisconductExamined(AllegationOfMisconductExamined AllegationOfMisconductExaminedModel)
        {
            try
            {
                var parameters = new[]
                {
                     new SqlParameter("@MasterReferenceId", AllegationOfMisconductExaminedModel.MasterReferenceId),
                      new SqlParameter("@officerId", AllegationOfMisconductExaminedModel.officerId),
                      new SqlParameter("@vigilanceAngleExamined", AllegationOfMisconductExaminedModel.vigilanceAngleExamined),
                      new SqlParameter("@caseDetails", AllegationOfMisconductExaminedModel.caseDetails),
                      new SqlParameter("@presentStatusOfTheCase", AllegationOfMisconductExaminedModel.presentStatusOfTheCase),
                      new SqlParameter("@actionrecommendedOptions", AllegationOfMisconductExaminedModel.actionrecommendedOptions),
                      new SqlParameter("@actionRecommendedDetails", AllegationOfMisconductExaminedModel.actionRecommendedDetails),
                      new SqlParameter("@CreatedBy", AllegationOfMisconductExaminedModel.ActionBy),
                      new SqlParameter("@CreatedOn", AllegationOfMisconductExaminedModel.ActionOn),
                      new SqlParameter("@CreatedBy_SessionId", AllegationOfMisconductExaminedModel.ActionBy_SessionId),
                      new SqlParameter("@CreatedBy_IP", AllegationOfMisconductExaminedModel.ActionBy_IP)
                };

                var result = await _vCDbContext.Database.ExecuteSqlRawAsync(
                              @"EXEC usp_tbl_Transaction_9_AllegationOfMisconductExamined_1_Insert 
                               @MasterReferenceId,
                               @officerId, 
                               @vigilanceAngleExamined, 
                               @caseDetails, 
                               @presentStatusOfTheCase, 
                               @actionrecommendedOptions, 
                               @actionRecommendedDetails, 
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
