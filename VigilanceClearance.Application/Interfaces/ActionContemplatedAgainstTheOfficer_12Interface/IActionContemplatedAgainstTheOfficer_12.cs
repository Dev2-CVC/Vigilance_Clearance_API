using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VigilanceClearance.Application.DTOs.Requests;
using VigilanceClearance.Application.DTOs.Responses;

namespace VigilanceClearance.Application.Interfaces.ActionContemplatedAgainstTheOfficer_12Interface
{
    public interface IActionContemplatedAgainstTheOfficer_12
    {
        public Task<BaseResponseModel> insertActionContemplatedAgainstTheOfficer(ActionContemplatedAgainstTheOfficer actionContemplatedAgainstTheOfficerModel);

        public Task<BaseResponseModel> GetActionContemplatedAgainstTheOfficelistById(long? id);
    }
}
