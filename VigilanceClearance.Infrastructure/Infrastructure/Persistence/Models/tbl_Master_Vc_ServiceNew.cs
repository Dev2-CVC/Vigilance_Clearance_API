using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VigilanceClearance.Infrastructure.Infrastructure.Persistence.Models
{
    public class tbl_Master_Vc_ServiceNew
    {
        [Key]
        public long? ServiceCodeId { get; set; }
        public string? ServiceName { get; set; }
        public string? ServiceCode { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string? CreatedByIP { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }  // nullable for optional updates
        public string? UpdatedByIP { get; set; }
        public string? SessionID { get; set; }
        public bool? IsActive { get; set; }
        public string? ActiveRemark { get; set; }
    }
}
