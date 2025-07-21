using System.ComponentModel.DataAnnotations;

namespace VigilanceClearance.Application.DTOs.Requests
{
  
        public class VcPostSubCategoryInsert
        {
        public int? Id { get; set; }

        [StringLength(50)]
        [RegularExpression(@"^([0-9]{1,3}\.){3}[0-9]{1,3}$", ErrorMessage = "SelectionForThePostCategory must be a valid IP format")]
        public string? SelectionForThePostCategory { get; set; }

        [StringLength(50)]
        [RegularExpression(@"^([0-9]{1,3}\.){3}[0-9]{1,3}$", ErrorMessage = "SelectionForThePostCategory_SubCode must be a valid IP format")]
        public string? SelectionForThePostCategory_SubCode { get; set; }
        [StringLength(50)]
        [RegularExpression(@"^([0-9]{1,3}\.){3}[0-9]{1,3}$", ErrorMessage = "SelectionForThePostCategory_SubCodeDesc must be a valid IP format")]
        public string? SelectionForThePostCategory_SubCodeDesc { get; set; }

        }
    }

