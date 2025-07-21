using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VigilanceClearance.Application.DTOs.Responses;

namespace VigilanceClearance.Application.Interfaces.UserInterface
{
    public interface IUserInterface
    {
        public Task<BaseResponseModel> GetUserDetailsByUserName(string UserName);
    }
}
