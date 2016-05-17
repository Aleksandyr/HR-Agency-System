namespace HRAgencySystem.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;


    public class UserRole
    {
        private ICollection<User> users;

        public UserRole()
        {
            this.users = new HashSet<User>();
        }

        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

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
