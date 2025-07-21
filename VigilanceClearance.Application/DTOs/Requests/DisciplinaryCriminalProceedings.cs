using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VigilanceClearance.Application.DTOs.Requests
{
    public class DisciplinaryCriminalProceedings
    {
        [Required(ErrorMessage = "OfficerId is required")]
        public long? officerId { get; set; }
        public string? whether_DisciplinaryCriminalProceedingsPending { get; set; }
        public string? whether_Suspended { get; set; }
        public DateTime? suspensionDate { get; set; }
        public string? whetherRevoked { get; set; }
        public DateTime? revocationDate { get; set; }
        public string? detailsOf_Case { get; set; }
        public string? presentStatusOftheCase { get; set; }
        public string? ActionBy { get; set; }       
        public string? ActionBy_SessionId { get; set; }
        public string? ActionBy_IP { get; set; }
    }
}
