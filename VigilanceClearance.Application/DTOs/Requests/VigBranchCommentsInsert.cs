using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VigilanceClearance.Application.DTOs.Requests
{
    public class VigBranchCommentsInsert
    {
        public long? MasterReferenceID { get; set; }
        public long? officerID { get; set; }
        public string? AdverseOrNothingAdverse { get; set; }
        public string? AdverseRemarks { get; set; }
        public string? CreatedById { get; set; }
    }
}