namespace HRAgencySystem.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class HallStatus
    {
        private ICollection<Hall> halls;

        public HallStatus()
        {
            this.halls = new HashSet<Hall>();
        }

        [Required]
        public int Id { get; set; }

        [Required]
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
