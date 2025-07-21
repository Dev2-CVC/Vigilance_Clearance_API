using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VigilanceClearance.Application.DTOs.Requests
{
    public class ForwardProposalTo_BranchesAndMinistryModel
    {
        [Required(ErrorMessage ="Master Reference ID Can not be null")]
        public long? MasterReferenceId { get; set; }
        public long? OfficerId { get; set; }
    }
}
