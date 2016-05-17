namespace HRAgencySystem.Models
{
    using System.ComponentModel.DataAnnotations;


    public class UserRole
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
