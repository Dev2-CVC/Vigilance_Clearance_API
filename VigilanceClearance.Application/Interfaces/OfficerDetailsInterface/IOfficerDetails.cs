using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VigilanceClearance.Application.DTOs.Requests;
using VigilanceClearance.Application.DTOs.Responses;

namespace VigilanceClearance.Application.Interfaces.OfficerDetailsInterface
{
    public interface IOfficerDetails
    {
        public Task<BaseResponseModel> OfficerDetailsGetById(long? id);
        public Task<BaseResponseModel> OfficerDetailsGetByMasterReferenceID(long? id);
        public Task<BaseResponseModel> OfficerDetailsInsert(OfficerDetailsInsert officerDetailsInsert);

        public Task<BaseResponseModel> OfficerDetails_GetByOfficerId_ForMinistry(long? OfficerId);

    }
}
