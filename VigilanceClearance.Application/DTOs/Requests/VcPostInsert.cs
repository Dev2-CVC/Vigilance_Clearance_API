using System.ComponentModel.DataAnnotations;
using VigilanceClearance.Application.DTOs.Responses;

namespace VigilanceClearance.Application.DTOs.RequestModel
{
    public class VcPostInsert : BaseResponseModel
    {


        public int? Id { get; set; }


        [Required(ErrorMessage = "PostCode is required")]
        [RegularExpression(@"^(?!string$)([a-zA-Z0-9\s]+)$", ErrorMessage = "PostCode cannot be 'string' or contain special characters")]
        [StringLength(50, ErrorMessage = "PostCode can't be longer than 50 characters")]
        
        public string PostCode { get; set; }

        [Required(ErrorMessage = "PostDescription is required")]
        [RegularExpression(@"^(?!string$)([a-zA-Z0-9\s]+)$", ErrorMessage = "PostDescription cannot be 'string' or contain special characters")]
        [StringLength(200, ErrorMessage = "PostDescription can't be longer than 200 characters")]
        public string PostDescription { get; set; }

        [RegularExpression(@"^(?!string$)([a-zA-Z0-9\s]+)$", ErrorMessage = "CreatedBy cannot be 'string' or contain special characters")]
        [StringLength(50)]
        public string? CreatedBy { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? CreatedOn { get; set; }

        [StringLength(50)]
        [RegularExpression(@"^([0-9]{1,3}\.){3}[0-9]{1,3}$", ErrorMessage = "CreatedByIp must be a valid IP format")]
        public string? CreatedByIp { get; set; }
         
        [StringLength(50)]
        [RegularExpression(@"^(?!string$)([a-zA-Z0-9\s]+)$", ErrorMessage = "CreatedBySession cannot be 'string' or contain special characters")]
        public string? CreatedBySession { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "UpdateBy is required")]
        [RegularExpression(@"^(?!string$)([a-zA-Z0-9\s]+)$", ErrorMessage = "UpdateBy cannot be 'string' or contain special characters")]
        public string UpdateBy { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? UpdatedOn { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "UpdatedBySessionId is required")]
        [RegularExpression(@"^(?!string$)([a-zA-Z0-9\s]+)$", ErrorMessage = "UpdatedBySessionId cannot be 'string' or contain special characters")]
        public string UpdatedBySessionId { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "UpdatedByIp is required")]
        [RegularExpression(@"^([0-9]{1,3}\.){3}[0-9]{1,3}$", ErrorMessage = "UpdatedByIp must be a valid IP format")]
        public string UpdatedByIp { get; set; }
    }

}
