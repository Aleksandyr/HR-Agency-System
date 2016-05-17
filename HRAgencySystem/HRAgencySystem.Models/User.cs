namespace HRAgencySystem.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Collections.Generic;


    public class User : IdentityUser
    {
        private ICollection<Reservation> reservations;

        public User()
        {
            this.reservations = new HashSet<Reservation>();
        }

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
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
}
