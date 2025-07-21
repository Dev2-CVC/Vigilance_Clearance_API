using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VigilanceClearance.Application.DTOs.Responses;

namespace VigilanceClearance.Application.DTOs.Requests
{
    public class OfficerPostingDetailsInsert
    {
        public long? MasterReferenceId { get; set; }

        [Required(ErrorMessage = "Please Enter vcOfficer Id")]
        public long? VcOfficerId { get; set; }

        [Required(ErrorMessage = "Please Enter OrgCode")]
        public string? OrgCode { get; set; }

        [Required(ErrorMessage = "Please Enter Desination")]
        public string? Designation { get; set; }
        public string? PlaceOfPosting { get; set; }
        public string? OrgMinistry { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public string? ActionBy { get; set; }
        public string? ActionBy_SessionId { get; set; }
        public string? ActionBy_IP { get; set; }
    }
}
