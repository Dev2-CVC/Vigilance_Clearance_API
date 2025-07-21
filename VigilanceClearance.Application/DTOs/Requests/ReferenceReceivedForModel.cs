using Microsoft.AspNetCore.Http.HttpResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VigilanceClearance.Application.Services.VcReferenceReceivedFor;

namespace VigilanceClearance.Application.DTOs.Requests
{
    public class ReferenceReceivedForModel
    {
        public string? ReferenceReceivedFor { get; set; }
        public string? ReferenceReceivedFrom { get; set; }
        public string? ReferenceReceivedFromCode { get; set; }
        public string? SelectionForThePostCategory { get; set; }
        public string? SelectionForThePostSubCategory { get; set; }
        public string? OrgCode { get; set; }
        public string? OrgName { get; set; }
        public string? MinCode { get; set; }
        public string? MinDesc { get; set; }
        public string? PendingWith { get; set; }
        public string? ReferenceID { get; set; }
        public string? CVC_ReferenceID_FileNo { get; set; }
        public string? ActionBy { get; set; }
        public string? ActionBy_SessionId { get; set; }
        public string? ActionBy_IP { get; set; }

    }
}
