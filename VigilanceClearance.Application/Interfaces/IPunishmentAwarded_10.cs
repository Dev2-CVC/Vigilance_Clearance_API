using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VigilanceClearance.Application.DTOs.Requests;
using VigilanceClearance.Application.DTOs.Responses;

namespace VigilanceClearance.Application.Interfaces
{
    public interface IPunishmentAwarded_10
    {
        public Task<BaseResponseModel> insertPunishmentAwarded(PunishmentAwarded punishmentAwardedModel);

        public Task<BaseResponseModel> GetPunishmentAwardedlistGetById(long? id);
    }
}
