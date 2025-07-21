using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VigilanceClearance.Application.DTOs.Requests;
using VigilanceClearance.Application.DTOs.Responses;

namespace VigilanceClearance.Application.Interfaces.ComplaintWithVigilanceAnglePending_13Interface
{
    public interface IComplaintWithVigilanceAnglePending
    {
        public Task<BaseResponseModel> insertComplaintWithVigilanceAnglePending(ComplaintWithVigilanceAnglePending complaintWithVigilanceAnglePendingModel);
        public Task<BaseResponseModel> GetComplaintWithVigilanceAnglePendinglistById(long? id);
    }
}
