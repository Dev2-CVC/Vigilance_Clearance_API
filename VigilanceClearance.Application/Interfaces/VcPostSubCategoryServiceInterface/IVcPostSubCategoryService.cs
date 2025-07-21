using System;
using VigilanceClearance.Application.DTOs.Requests;
using VigilanceClearance.Application.DTOs.Responses;

namespace VigilanceClearance.Application.Interfaces.VcPostSubServiceInterface
{
    public interface IVcPostSubCategoryService
    {
        public Task<BaseResponseModel> VcPostSubCategoryInsert(VcPostSubCategoryInsert vcPostSubCategory);
        public Task<BaseResponseModel> VcPostSubCategoryUpdate(VcPostSubCategoryInsert vcPostSubCategory);
    }
}
