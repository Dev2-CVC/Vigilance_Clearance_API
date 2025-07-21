using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VigilanceClearance.Application.DTOs.Requests
{
    public class ReferenceFromPESBUpdate
    {
        public int MainReferenceID { get; set; }
        public string? PendingWith { get; set; }
        public string? UpdatedBy { get; set; }
        public string? UpdatedBy_SessionId { get; set; }
        public string? UpdatedBy_IP { get; set; }
    }
}
