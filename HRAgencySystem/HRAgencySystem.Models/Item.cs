using System.ComponentModel.DataAnnotations;

namespace HRAgencySystem.Models
{
    public class Item
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        public int HallId { get; set; }

        public virtual Hall Hall { get; set; }
    }
}
