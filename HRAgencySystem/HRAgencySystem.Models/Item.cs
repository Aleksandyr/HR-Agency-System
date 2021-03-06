﻿namespace HRAgencySystem.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Item
    {
        private ICollection<Hall> halls;

        public Item()
        {
            this.halls = new HashSet<Hall>();
        }

        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

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
