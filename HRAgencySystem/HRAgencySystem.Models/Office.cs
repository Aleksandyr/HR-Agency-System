namespace HRAgencySystem.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Office
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(500)]
        public string Description { get; set; }
    }
}
