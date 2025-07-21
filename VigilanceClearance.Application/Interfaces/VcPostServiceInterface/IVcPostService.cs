using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VigilanceClearance.Application.DTOs.RequestModel;
using VigilanceClearance.Application.DTOs.Responses;
using VigilanceClearance.Application.DTOs.Responses.VcPost;

namespace VigilanceClearance.Application.Interfaces.VcPostServiceInterface
{
    public interface IVcPostService
    {
        public Task<BaseResponseModel> VcPostInsert(VcPostInsert vcPostInsert);
        public Task<BaseResponseModel> VcPostUpdate(VcPostInsert vcPostInsert);
        

    }
}
