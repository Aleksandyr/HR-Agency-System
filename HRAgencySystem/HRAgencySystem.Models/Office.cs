﻿namespace HRAgencySystem.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Office
    {
        private ICollection<Hall> halls;

        public Office()
        {
            this.halls = new HashSet<Hall>();
        }

        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(500)]
        public string Description { get; set; }

        public virtual ICollection<Hall> Halls
        {
            get
            {
                return this.halls;
            }
            set
            {
                this.halls = value;
            }

        }
    }
}
