using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using HRAgencySystem.Common;

namespace HRAgencySystem.Web.Areas.Admin.InputModels.Hall
{
    public class EditHallInputModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = GlobalConstants.RequiredValidationMessage)]
        [StringLength(50, ErrorMessage = GlobalConstants.StringLengthValidationMessage)]
        public string Name { get; set; }

        [StringLength(500, ErrorMessage = GlobalConstants.StringLengthValidationMessage)]
        public string Description { get; set; }

        [Required]
        public int Capacity { get; set; }

        [Required]
        [Display(Name = "Office")]
        public int OfficeId { get; set; }

        [Required]
        [Display(Name = "Hall status")]
        public int HallStatusId { get; set; }
    }

}