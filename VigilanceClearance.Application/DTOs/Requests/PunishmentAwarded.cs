using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VigilanceClearance.Application.DTOs.Requests
{
    public class PunishmentAwarded
    {
        [Required(ErrorMessage = "OfficerId is required")]
        public long? officerId { get; set; }
        public string? punishmentAwarded { get; set; }
        public string? punishmentDetails { get; set; }
        public DateTime? punishmentFromDate { get; set; }
        public DateTime? punishmentToDate { get; set; }
        public DateTime? checkName_FromDate { get; set; }
        public DateTime? checkName_ToDate { get; set; }
        public string? additionalRemarks_IfAny { get; set; }
        public string? ActionBy { get; set; }
        //public DateTime? ActionOn { get; set; }
        public string? ActionBy_SessionId { get; set; }
        public string? ActionBy_IP { get; set; }
    }
}
