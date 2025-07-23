using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VigilanceClearance.Application.DTOs.Requests
{
    public class ActionContemplatedAgainstTheOfficer
    {
        [Required(ErrorMessage = "Please Enter MasterReference Id")]
        public long? MasterReferenceId { get; set; }
        [Required(ErrorMessage ="Officer ID Required")]
        public long? officerId { get; set; }
        public string? whether_CaseContemplated { get; set; }
        public string? detailsOfTheCase { get; set; }
        public string? presentStatusOftheCase { get; set; }
        public string? ActionBy { get; set; }
        public string? ActionBy_SessionId { get; set; }
        public string? ActionBy_IP { get; set; }
    }
}
