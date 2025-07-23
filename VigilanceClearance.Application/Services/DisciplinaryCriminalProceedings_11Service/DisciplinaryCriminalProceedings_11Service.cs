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
using VigilanceClearance.Application.Interfaces.DisciplinaryCriminalProceedings_11Interface;
using VigilanceClearance.Infrastructure.Common.Helpers;
using VigilanceClearance.Infrastructure.Infrastructure.Persistence.DbContexts;

namespace VigilanceClearance.Application.Services.DisciplinaryCriminalProceedings_11Service
{
    public class DisciplinaryCriminalProceedings_11Service : IDisciplinaryCriminalProceedings_11
    {
        private readonly VCDbContext _vCDbContext;
        private readonly ILogger<DisciplinaryCriminalProceedings_11Service> _logger;
        private readonly ILogService _logService;
        public DisciplinaryCriminalProceedings_11Service(VCDbContext vCDbContext, ILogger<DisciplinaryCriminalProceedings_11Service> logger, ILogService logService)
        {
            _vCDbContext = vCDbContext;
            _logger = logger;
            _logService = logService;
        }

        public async Task<BaseResponseModel> insertDisciplinaryCriminalProceedings(DisciplinaryCriminalProceedings disciplinaryCriminalProceedingsModel)
        {
            try
            {
                var parameters = new[]
                {
                     new SqlParameter("@MasterReferenceId", disciplinaryCriminalProceedingsModel.MasterReferenceId),
                      new SqlParameter("@officerId", disciplinaryCriminalProceedingsModel.officerId),
                      new SqlParameter("@whether_DisciplinaryCriminalProceedingsPending", disciplinaryCriminalProceedingsModel.whether_DisciplinaryCriminalProceedingsPending),
                      new SqlParameter("@whether_Suspended", disciplinaryCriminalProceedingsModel.whether_Suspended),
                      //new SqlParameter("@suspensionDate", disciplinaryCriminalProceedingsModel.suspensionDate),
                      new SqlParameter("@suspensionDate", (object?)disciplinaryCriminalProceedingsModel.suspensionDate ?? DBNull.Value),
                      new SqlParameter("@whetherRevoked", disciplinaryCriminalProceedingsModel.whetherRevoked),
                      //new SqlParameter("@revocationDate", disciplinaryCriminalProceedingsModel.revocationDate),
                      new SqlParameter("@revocationDate", (object?)disciplinaryCriminalProceedingsModel.revocationDate ?? DBNull.Value),
                      new SqlParameter("@detailsOf_Case", disciplinaryCriminalProceedingsModel.detailsOf_Case),
                      new SqlParameter("@presentStatusOftheCase", disciplinaryCriminalProceedingsModel.presentStatusOftheCase),
                      new SqlParameter("@CreatedBy", disciplinaryCriminalProceedingsModel.ActionBy),
                      new SqlParameter("@CreatedBy_SessionId", disciplinaryCriminalProceedingsModel.ActionBy_SessionId),
                      new SqlParameter("@CreatedBy_IP", disciplinaryCriminalProceedingsModel.ActionBy_IP)
                };

                var result = await _vCDbContext.Database.ExecuteSqlRawAsync(
                              @"EXEC usp_tbl_Transaction_11_DisciplinaryCriminalProceedings_1_Insert 
                               @MasterReferenceId,
                               @officerId, 
                               @whether_DisciplinaryCriminalProceedingsPending, 
                               @whether_Suspended, 
                               @suspensionDate, 
                               @whetherRevoked, 
                               @revocationDate, 
                               @detailsOf_Case, 
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
                _logger.LogError(ex, "Failed to Insert usp_tbl_Transaction_11_DisciplinaryCriminalProceedings_1_Insert ");

                await _logService.LogAsync(
                    $"Failed to Insert usp_tbl_Transaction_11_DisciplinaryCriminalProceedings_1_Insert ",
                    ex.StackTrace ?? "",
                    "Error"
                );

                return BaseResponseFactory.Error();
            }
        }


        public async Task<BaseResponseModel> GetdisciplinaryCriminalProceedingslistById(long? id)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@id", id, DbType.Int64);


                var result = await DapperHelper.QueryAsync(
                    _vCDbContext,
                    "[usp_tbl_Transaction_11_DisciplinaryCriminalProceedings_4_GetById]",
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
