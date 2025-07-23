using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VigilanceClearance.Application.DTOs.Requests;
using VigilanceClearance.Application.DTOs.Responses;

namespace VigilanceClearance.Application.Interfaces.DealingHand
{
    public interface IDealingHand
    {
        public Task<BaseResponseModel> GetPendingListFor_BranchDH(string Branch);
        public Task<BaseResponseModel> OfficerDetailsForCVCUsers_List(int masterRefid, string Branch);
        public Task<BaseResponseModel> VigBranchCommentsInsert(VigBranchCommentsInsert vigBranchCommentsobj);
        public Task<BaseResponseModel> GetVigBranchComments(long masterRefid, long Officerid);
    }
}
