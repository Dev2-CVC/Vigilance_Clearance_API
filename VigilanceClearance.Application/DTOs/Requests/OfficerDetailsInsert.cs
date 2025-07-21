using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VigilanceClearance.Application.DTOs.Requests
{
    public class OfficerDetailsInsert
    {


        public long? MasterReferenceID { get; set; }

        //public string? SelectionForThePostCategory { get; set; }
        //public string? SelectionForThePostSubCategory { get; set; }
        //public string? ReferenceReceivedFor { get; set; }
        //public string? OthersRemarks { get; set; }

        //[Required(ErrorMessage = "OrgCode is required")]
        //public string? OrgCode { get; set; }

        //[Required(ErrorMessage = "Officer Name is required")]
        public string? Officer_Name { get; set; }

        public string? Officer_FatherName { get; set; }

        public DateTime? Officer_DateOfBirth { get; set; }
        public DateTime? Officer_RetirementDate { get; set; }
        public DateTime? Officer_ServiceEntryDate { get; set; }

        public string? Officer_Service { get; set; }
        public string? Officer_Other_Service { get; set; }
        public int? Officer_Batch_Year { get; set; }
        public string? Officer_Cadre { get; set; }

        //public string? OfficerPostingDetails_7 { get; set; }
        //public string? IntegrityAgreedOrDoubtful_8 { get; set; }
        //public string? AllegationOfMisconductExamined_9 { get; set; }
        //public string? PunishmentAwarded_10 { get; set; }
        //public string? DisciplinaryCriminalProceedings_11 { get; set; }
        //public string? ActionContemplatedAgainstTheOfficerAsOnDate_12 { get; set; }
        //public string? ComplaintWithVigilanceAnglePending_13 { get; set; }

        public string? CreatedBy { get; set; }
        //public DateTime? CreatedOn { get; set; }
        public string? CreatedBy_SessionId { get; set; }
        public string? CreatedBy_IP { get; set; }

        //public string? UpdateBy { get; set; }
        //public DateTime? UpdatedOn { get; set; }
        //public string? UpdatedBy_SessionId { get; set; }
        //public string? UpdatedBy_IP { get; set; }

        //public string? PendingWith { get; set; }
        //public string? UID { get; set; }
    }
}
