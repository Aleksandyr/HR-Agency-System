using System.Collections.Generic;
using System.Web.Mvc;
using HRAgencySystem.Models;

namespace HRAgencySystem.Web.Areas.InputModels.Registration
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using HRAgencySystem.Common;

    public class ReservationInputModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = GlobalConstants.RequiredValidationMessage)]
        [StringLength(500, ErrorMessage = GlobalConstants.StringLengthValidationMessage)]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Hall")]
        public int HallId { get; set; }

        public List<string> UserIds { get; set; }

        [Display(Name = "Users")]
        public MultiSelectList Users { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
    }
}