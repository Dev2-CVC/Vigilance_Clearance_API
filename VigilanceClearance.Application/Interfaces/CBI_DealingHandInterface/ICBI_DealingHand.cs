using VigilanceClearance.Application.DTOs.Requests;
using VigilanceClearance.Application.DTOs.Responses;

namespace VigilanceClearance.Application.Interfaces.CBI_DealingHandInterface
{
    public interface ICBI_DealingHand
    {
        public Task<BaseResponseModel> FeebbackOf_CBI(FeebbackOfCbiInsert model); 
        public Task<BaseResponseModel> CVC_ForwardToCBI(int id);
        public Task<BaseResponseModel> OfficerDetailWithFeebbackOf_CBI(long masterReferenceID);
    }
}
