namespace HRAgencySystem.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Hall
    {
        private ICollection<Reservation> reservations;
        private ICollection<Item> items;

        public Hall()
        {
            this.reservations = new HashSet<Reservation>();
            this.items = new HashSet<Item>();
        }

        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

        [Required]
        public int Capacity { get; set; }

        [Required]
        public int OfficeId { get; set; }

        public virtual Office Office { get; set; }

        [Required]
        public int StatusId { get; set; }

        public virtual Status Status { get; set; }

        public virtual ICollection<Reservation> Reservations
        {
            get
            {
                return this.reservations;
            }
            set
            {
                this.reservations = value;
            }
        }

        public virtual ICollection<Item> Items
        {
            get
            {
                return this.items;
            }
            set
            {
                this.items = value;
            }
        }
    }
}
