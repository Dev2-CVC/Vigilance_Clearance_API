using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Extensions.Logging;
using VigilanceClearance.Application.Common.Helpers;
using VigilanceClearance.Application.DTOs.Responses;
using VigilanceClearance.Application.Interfaces;
using VigilanceClearance.Infrastructure.Common.Helpers;
using VigilanceClearance.Infrastructure.Infrastructure.Persistence.DbContexts;

namespace VigilanceClearance.Application.Services.MinistryService
{
    public class MinistryService : IMinistry
    {
        private readonly VCDbContext _vCDbContext;
        private readonly ILogger<MinistryService> _logger;
        private readonly ILogService _logService;
        public MinistryService(VCDbContext vCDbContext, ILogger<MinistryService> logger, ILogService logService)
        {
            _vCDbContext = vCDbContext;
            _logger = logger;
            _logService = logService;
        }

        public async Task<BaseResponseModel> GetReferenceListPendingWithMinistryApprover(string MinCode, string Role)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@MinCode", MinCode, DbType.String);
                parameters.Add("@Role", Role, DbType.String);

                var result = await DapperHelper.QueryAsync(
                    _vCDbContext,
                    "[usp_GetReferenceListPendingWith_MinistryApprover]",
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
                _logger.LogError(ex, "Failed to retrieve data for Ministry with Role: {Role}", Role);

                await _logService.LogAsync(
                    $"Failed to retrieve data for Ministry with Role: {Role}",
                    ex.StackTrace ?? "",
                    "Error"
                );

                return BaseResponseFactory.Error(ApplicationMessages.DataNotRetrivedError);
            }
        }






    }
}
