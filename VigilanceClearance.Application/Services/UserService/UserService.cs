using Dapper;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VigilanceClearance.Application.Common.Helpers;
using VigilanceClearance.Application.DTOs.Responses;
using VigilanceClearance.Application.Interfaces;
using VigilanceClearance.Application.Interfaces.UserInterface;
using VigilanceClearance.Infrastructure.Common.Helpers;
using VigilanceClearance.Infrastructure.Infrastructure.Persistence.DbContexts;

namespace VigilanceClearance.Application.Services.UserService
{
    public class UserService :IUserInterface
    {
        private readonly VCDbContext _vCDbContext;
        private readonly ILogger<UserService> _logger;
        private readonly ILogService _logService;
        public UserService(VCDbContext vCDbContext, ILogger<UserService> logger, ILogService logService)
        {
            _vCDbContext = vCDbContext;
            _logger = logger;
            _logService = logService;
        }

        public async Task<BaseResponseModel> GetUserDetailsByUserName(string UserName)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@UserName", UserName );


                var result = await DapperHelper.QueryAsync(
                    _vCDbContext,
                    "[usp_GetUserInfo]",
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
                _logger.LogError(ex, "Failed to retrieve User Details  with user name: {username}", UserName);

                await _logService.LogAsync(
                    $"Failed to retrieve data for OfficerDetails with ID: {UserName}",
                    ex.StackTrace ?? "",
                    "Error"
                );

                return BaseResponseFactory.Error(ApplicationMessages.DataNotRetrivedError);
            }
        }

    }
}
