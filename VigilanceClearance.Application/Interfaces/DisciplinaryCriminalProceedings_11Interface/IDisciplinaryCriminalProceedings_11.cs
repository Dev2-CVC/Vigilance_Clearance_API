using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VigilanceClearance.Application.DTOs.Requests;
using VigilanceClearance.Application.DTOs.Responses;

namespace VigilanceClearance.Application.Interfaces.DisciplinaryCriminalProceedings_11Interface
{
    public interface IDisciplinaryCriminalProceedings_11
    {
        public Task<BaseResponseModel> insertDisciplinaryCriminalProceedings(DisciplinaryCriminalProceedings disciplinaryCriminalProceedingsModel);

        public Task<BaseResponseModel> GetdisciplinaryCriminalProceedingslistById(long? id);
    }
}
