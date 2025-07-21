using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VigilanceClearance.Application.DTOs.Responses;

namespace VigilanceClearance.Application.DTOs.Requests
{
    public class VcReferenceInsert
    {
        public string? ReferenceDesc { get; set; }

        public string? ReferenceCode { get; set; }

        public string? CreatedBy { get; set; }

        public DateTime? CreatedOn { get; set; }

        public string? CreatedBySessionId { get; set; }

        public string? CreatedByIp { get; set; }

        public string? UpdateBy { get; set; }

        public DateTime? UpdatedOn { get; set; }

        public string? UpdatedBySessionId { get; set; }

        public string? UpdatedByIp { get; set; }
    }
}
