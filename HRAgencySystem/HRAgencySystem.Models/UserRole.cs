﻿namespace HRAgencySystem.Models
{
    using System.ComponentModel.DataAnnotations;


    public class UserRole
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
    }
}
