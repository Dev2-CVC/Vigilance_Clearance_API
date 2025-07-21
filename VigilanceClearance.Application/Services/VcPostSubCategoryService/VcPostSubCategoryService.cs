using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using VigilanceClearance.Application.Common.Helpers;
using VigilanceClearance.Application.DTOs.Requests;
using VigilanceClearance.Application.DTOs.Responses;
using VigilanceClearance.Application.Interfaces;
using VigilanceClearance.Application.Interfaces.VcPostSubServiceInterface;
using VigilanceClearance.Infrastructure.Common.Helpers;
using VigilanceClearance.Infrastructure.Infrastructure.Persistence.DbContexts;

namespace VigilanceClearance.Application.Services.VcPostSubService
{
    public class VcPostSubCategoryService: IVcPostSubCategoryService
    {
        public readonly VCDbContext _vCDbContext;
        private readonly ILogger<VcPostSubCategoryService> _logger;
        private readonly ILogService _logService;
        public VcPostSubCategoryService(VCDbContext vCDbContext, ILogger<VcPostSubCategoryService> logger, ILogService logService)
        {
            _vCDbContext = vCDbContext;
            _logger = logger;
            _logService = logService;
        }
       

       


        public async Task<BaseResponseModel> VcPostSubCategoryInsert(VcPostSubCategoryInsert vcPostSubCategory)
        {
            
            try
            {
                var param = new[]
                {
                new SqlParameter("@selectionForThePostCategory",vcPostSubCategory.SelectionForThePostCategory ?? (object)DBNull.Value),
                 new SqlParameter("@selectionForThePostCategory_SubCode",vcPostSubCategory.SelectionForThePostCategory_SubCode ?? (object)DBNull.Value),
                 new SqlParameter("@selectionForThePostCategory_SubCodeDesc",vcPostSubCategory.SelectionForThePostCategory_SubCodeDesc ?? (object)DBNull.Value),

            };
                var result = await _vCDbContext.Database.ExecuteSqlRawAsync(
                     "EXEC usp_tbl_Master_Vc_Post_SubCategory_1_Insert @selectionForThePostCategory,@selectionForThePostCategory_SubCode,@selectionForThePostCategory_SubCodeDesc", param
                                   );
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
                _logger.LogError(ex, "Failed to Insert usp_tbl_Master_Vc_Post_SubCategory_1_Insert ");

                await _logService.LogAsync(
                    $"Failed to Insert usp_tbl_Master_Vc_Post_SubCategory_1_Insert ",
                    ex.StackTrace ?? "",
                    "Error"
                );

                return BaseResponseFactory.Error();
            }
        }
        public async Task<BaseResponseModel> VcPostSubCategoryUpdate(VcPostSubCategoryInsert vcPostSubCategory)
        {
            try
            {
                var param = new[]
                {
                    new SqlParameter("@Id", vcPostSubCategory.Id.HasValue ? vcPostSubCategory.Id.Value : (object)DBNull.Value),
                 new SqlParameter("@selectionForThePostCategory",vcPostSubCategory.SelectionForThePostCategory ?? (object)DBNull.Value),
                 new SqlParameter("@selectionForThePostCategory",vcPostSubCategory.SelectionForThePostCategory ?? (object)DBNull.Value),
                 new SqlParameter("@selectionForThePostCategory_SubCode",vcPostSubCategory.SelectionForThePostCategory_SubCode ?? (object)DBNull.Value),
                 new SqlParameter("@selectionForThePostCategory_SubCodeDesc",vcPostSubCategory.SelectionForThePostCategory_SubCodeDesc ?? (object)DBNull.Value),

            };
                var result = await _vCDbContext.Database.ExecuteSqlRawAsync(
                     "EXEC usp_tbl_Master_Vc_Post_SubCategory_2_Update @Id,@selectionForThePostCategory,@selectionForThePostCategory_SubCode,@selectionForThePostCategory_SubCodeDesc", param
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
                _logger.LogError(ex, "Failed to Update usp_tbl_Master_Vc_Post_SubCategory_2_Update ");

                await _logService.LogAsync(
                    $"Failed to Update usp_tbl_Master_Vc_Post_SubCategory_2_Update ",
                    ex.StackTrace ?? "",
                    "Error"
                );

                return BaseResponseFactory.Error(ApplicationMessages.RecordUpdatedError);
            }
        }
    }
}
