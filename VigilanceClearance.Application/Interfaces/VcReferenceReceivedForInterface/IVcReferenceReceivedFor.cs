using VigilanceClearance.Application.DTOs.Requests;
using VigilanceClearance.Application.DTOs.Responses;
using VigilanceClearance.Infrastructure.Infrastructure.Persistence.Models;

namespace VigilanceClearance.Application.Interfaces.VcReferenceReceivedForInterface
{
    public interface IVcReferenceReceivedFor
    {
        public Task<BaseResponseModel> VcReferenceReceivedForGetById(long? id, string? UserName);
        public Task<BaseResponseModel> VcReferenceReceivedDetailsGetById(long? id);

        public Task<BaseResponseModel> VcReferenceReceivedDetailsUpdateById(VcReferenceReceivedForUpdate model);
        public Task<BaseResponseModel> VcReferenceReceivedDetailsGetAll();
        public Task<BaseResponseModel> VcReferenceReceivedForInsert(TblMasterVcReferenceReceivedFor tblMasterVcReferencefor);
        public Task<BaseResponseModel> ReferenceReceivedForInsert(ReferenceReceivedForModel modelobj);
        public Task<BaseResponseModel> ReferenceFromPESBUpdate(ReferenceFromPESBUpdate modelobj);
    }
}
