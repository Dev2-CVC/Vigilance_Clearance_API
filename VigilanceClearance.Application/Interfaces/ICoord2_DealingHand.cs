using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VigilanceClearance.Application.DTOs.Requests;
using VigilanceClearance.Application.DTOs.Responses;

namespace VigilanceClearance.Application.Interfaces
{
    public interface ICoord2_DealingHand
    {
        public Task<BaseResponseModel> OfficerDetailWithPostingDetails(long masterReferenceID);

        public Task<BaseResponseModel> ForwardProposalTo_BranchesAndMinistry(ForwardProposalTo_BranchesAndMinistryModel forwardProposalTo_BranchesAndMinistryModel);
    }
}
