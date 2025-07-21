using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VigilanceClearance.Application.DTOs.Requests;
using VigilanceClearance.Application.DTOs.Responses;

namespace VigilanceClearance.Application.Interfaces.IntegrityAgreedOrDoubtfuliNTERFACE
{
    public  interface IIntegrityAgreedOrDoubtful
    {
        public Task<BaseResponseModel> IntegrityAgreedOrDoubtfulInsert(IntegrityAgreedOrDoubtfulInsert IntegrityAgreedOrDoubtful);
        public Task<BaseResponseModel> IntegrityAgreedOrDoubtfulGetByOfficerID(long? id);
        
    }
}
;