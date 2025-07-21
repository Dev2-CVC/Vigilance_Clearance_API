using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VigilanceClearance.Application.DTOs.Requests
{
    public class IntegrityAgreedOrDoubtfulInsert
    {

        [Required(ErrorMessage = "OfficerId is required")]
       
        public long? OfficerId { get; set; }

      
        public string? EnteredInTheList { get; set; }

        public DateTime? DateOfEntryInTheList { get; set; }

        
        public string? RemovedFromTheList { get; set; }

       
        public string? DateOfRemovalFromTheList { get; set; }


        public string? ActionBy { get; set; }
        public DateTime? ActionOn { get; set; }
        public string? ActionBy_SessionId { get; set; }
        public string? ActionBy_IP { get; set; }

        //public string? UpdateBy { get; set; }
        //public DateTime? UpdatedOn { get; set; }
        //public string? UpdatedBy_SessionId { get; set; }
        //public string? UpdatedBy_IP { get; set; }
    }
}
