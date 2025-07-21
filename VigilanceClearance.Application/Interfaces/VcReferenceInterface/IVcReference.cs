using VigilanceClearance.Application.DTOs.Requests;
using VigilanceClearance.Application.DTOs.Responses;

namespace VigilanceClearance.Application.Interfaces.VcReferenceInterface
{
    public interface IVcReference
    {
        public Task<BaseResponseModel> VcReferenceInsert(VcReferenceInsert vcReferenceInsert);
      //  public Task<VcReferenceInsert> VcReferenceGetById(VcReferenceGet vcReferenceget);
    }
}
