using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VigilanceClearance.Application.DTOs.Responses;

namespace VigilanceClearance.Application.Interfaces
{
    public interface IMinistry
    {
        public Task<BaseResponseModel> GetReferenceListPendingWithMinistryApprover(string MinCode, string Role);
    }
}
