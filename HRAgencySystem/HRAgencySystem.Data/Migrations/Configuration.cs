
namespace HRAgencySystem.Data.Migrations
{
    using System.Linq;
    using System.Data.Entity.Migrations;

    using Models;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    internal sealed class Configuration : DbMigrationsConfiguration<HRAgancyDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(HRAgancyDbContext context)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;

            if (!context.Roles.Any(r => r.Name == "Admin"))
            {
                this.SeedRole(context);
            }

            if (!context.Users.Any())
            {
                this.SeedUsers(context);
            }
        }

        private void SeedRole(HRAgancyDbContext context)
        {
            var store = new RoleStore<IdentityRole>(context);
            var manager = new RoleManager<IdentityRole>(store);
            var role = new IdentityRole { Name = "Admin" };

            manager.Create(role);
        }

        private void SeedUsers(HRAgancyDbContext context)
        {
            var UserManager = new UserManager<User>(new UserStore<User>(context));
            var PasswordHash = new PasswordHasher();

            var user = new User
            {
                UserName = "someUser",
                Email = "someUser@example.com",
                PasswordHash = PasswordHash.HashPassword("password123")
            };

            UserManager.Create(user);

            var user1 = new User
            {
                UserName = "newUser",
                Email = "new_user@gmail.com",
                PasswordHash = PasswordHash.HashPassword("password123")
            };

            UserManager.Create(user1);

            if (!context.Users.Any(u => u.UserName == "admin"))
            {
                var user2 = new User
                {
                    UserName = "admin",
                    Email = "admin@snippy.softuni.com",
                    PasswordHash = PasswordHash.HashPassword("admin123")
                };

                UserManager.Create(user2);
                UserManager.AddToRole(user2.Id, "Admin");
            }
        }
    }
}
