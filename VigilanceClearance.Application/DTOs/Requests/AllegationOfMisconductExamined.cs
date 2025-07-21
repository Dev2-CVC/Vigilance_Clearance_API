using Microsoft.AspNetCore.Http.HttpResults;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VigilanceClearance.Application.DTOs.Requests
{
    public class AllegationOfMisconductExamined
    {
        [Required(ErrorMessage = "OfficerId is required")]
        public long? officerId { get; set; }
        public string? vigilanceAngleExamined { get; set; }
        public string? caseDetails { get; set; }
        public string? presentStatusOfTheCase { get; set; }
        public string? actionrecommendedOptions { get; set; }
        public string? actionRecommendedDetails { get; set; }
        public string? ActionBy { get; set; }
        public DateTime? ActionOn { get; set; }
        public string? ActionBy_SessionId { get; set; }
        public string? ActionBy_IP { get; set; }
    }
}
