namespace HRAgencySystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;


    public class Reservation
    {
        private ICollection<User> users;

        public Reservation()
        {
            this.users = new HashSet<User>();
        }

        [Required]
        public int Id { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [Required]
        public int HallId { get; set; }

        public virtual Hall Hall{ get; set; }

        public virtual ICollection<User> Users
        {
            get
            {
                return this.users;
            }
            set
            {
                this.users = value;
            }
        }
    }
}
