using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VigilanceClearance.Application.DTOs.Requests;
using VigilanceClearance.Application.DTOs.Responses;

namespace VigilanceClearance.Application.Interfaces.OfficerPostingDetailsInterface
{
    public interface IOfficerPostingDetails
    {

        public Task<BaseResponseModel> OfficerPostingDetailsGetById(long? id);
        public Task<BaseResponseModel> OfficerPostingDetailsGetByOfficerId(long? id);
        public Task<BaseResponseModel> OfficerPostingDetailsInsert(OfficerPostingDetailsInsert officerPostingDetailsInsert);
        public Task<BaseResponseModel> GetOfficerPostingDetailsByPostingId(long id);


    }
}
