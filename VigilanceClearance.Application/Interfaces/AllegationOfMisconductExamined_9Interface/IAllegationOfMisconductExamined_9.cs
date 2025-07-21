using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VigilanceClearance.Application.DTOs.Requests;
using VigilanceClearance.Application.DTOs.Responses;

namespace VigilanceClearance.Application.Interfaces.AllegationOfMisconductExamined_9Interface
{
    public interface IAllegationOfMisconductExamined_9
    {
        public Task<BaseResponseModel> AllegationOfMisconductExamined_9GetById(long? id);

        public Task<BaseResponseModel> insertAllegationOfMisconductExamined(AllegationOfMisconductExamined AllegationOfMisconductExaminedModel);
    }
}
