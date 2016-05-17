
using System.Collections.Generic;

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

            if (!context.Offices.Any())
            {
                this.SeedOffices(context);
            }

            if (!context.HallStatuses.Any())
            {
                this.SeedHallStatuses(context);
            }

            if (!context.Items.Any())
            {
                this.SeedItems(context);
            }

            if (!context.Halls.Any())
            {
                this.SeedHalls(context);
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
                Email = "newUser@gmail.com",
                PasswordHash = PasswordHash.HashPassword("password123")
            };

            UserManager.Create(user1);

            if (!context.Users.Any(u => u.UserName == "admin"))
            {
                var user2 = new User
                {
                    UserName = "admin",
                    Email = "admin@gmail.com",
                    PasswordHash = PasswordHash.HashPassword("admin123")
                };

                UserManager.Create(user2);
                UserManager.AddToRole(user2.Id, "Admin");
            }
        }

        private void SeedOffices(HRAgancyDbContext context)
        {
            var office = new Office
            {
                Name = "HR Office",
                Description = "This is the newest office"
            };

            context.Offices.Add(office);
            context.SaveChanges();
        }

        private void SeedHallStatuses(HRAgancyDbContext context)
        {
            var activeStatus = new HallStatus
            {
                Name = "Active"
            };

            var inactiveStatus = new HallStatus
            {
                Name = "InActive"
            };

            context.HallStatuses.Add(activeStatus);
            context.HallStatuses.Add(inactiveStatus);

            context.SaveChanges();
        }

        private void SeedItems(HRAgancyDbContext context)
        {
            var listOfItems = new List<string>()
            {
                "TV",
                "Projector"
            };

            foreach (var currItem in listOfItems)
            {
                var item = new Item
                {
                    Name = currItem
                };

                context.Items.Add(item);
            }

            context.SaveChanges();
        }

        private void SeedHalls(HRAgancyDbContext context)
        {
            var firstHall = new Hall
            {
                Name = "Hall 1",
                Description = "Hall with 30 places with TV",
                Capacity = 30,
                Office = context.Offices.FirstOrDefault(o => o.Name == "HR Office"),
                HallStatus = context.HallStatuses.FirstOrDefault(s => s.Name == "Active"),
                Items = context.Items.Where(i => i.Name == "TV").ToList()
            };

            context.Halls.Add(firstHall);

            var secondHall = new Hall
            {
                Name = "Hall 2",
                Description = "Hall with 30 places with Projector",
                Capacity = 30,
                Office = context.Offices.FirstOrDefault(o => o.Name == "HR Office"),
                HallStatus = context.HallStatuses.FirstOrDefault(s => s.Name == "Active"),
                Items = context.Items.Where(i => i.Name == "Projector").ToList()
            };

            context.Halls.Add(secondHall);

            var thirdHall = new Hall
            {
                Name = "Hall 3",
                Description = "Hall with 15 places with TV",
                Capacity = 15,
                Office = context.Offices.FirstOrDefault(o => o.Name == "HR Office"),
                HallStatus = context.HallStatuses.FirstOrDefault(s => s.Name == "Active"),
                Items = context.Items.Where(i => i.Name == "TV").ToList()
            };

            context.Halls.Add(thirdHall);

            var fourthHall = new Hall
            {
                Name = "Hall 4",
                Description = "Hall with 15 places with Projector",
                Capacity = 15,
                Office = context.Offices.FirstOrDefault(o => o.Name == "HR Office"),
                HallStatus = context.HallStatuses.FirstOrDefault(s => s.Name == "Active"),
                Items = context.Items.Where(i => i.Name == "Projector").ToList()
            };

            context.Halls.Add(fourthHall);

            var fifthHall = new Hall
            {
                Name = "Hall 5",
                Description = "Hall with 15 places with Projector",
                Capacity = 15,
                Office = context.Offices.FirstOrDefault(o => o.Name == "HR Office"),
                HallStatus = context.HallStatuses.FirstOrDefault(s => s.Name == "Active"),
                Items = context.Items.Where(i => i.Name == "Projector").ToList()
            };

            context.Halls.Add(fifthHall);

            var sixthHall = new Hall
            {
                Name = "Hall 6",
                Description = "Hall with 10 places with Projector",
                Capacity = 10,
                Office = context.Offices.FirstOrDefault(o => o.Name == "HR Office"),
                HallStatus = context.HallStatuses.FirstOrDefault(s => s.Name == "Active"),
                Items = context.Items.Where(i => i.Name == "Projector").ToList()
            };

            context.Halls.Add(sixthHall);

            var seventhHall = new Hall
            {
                Name = "Hall 7",
                Description = "Hall with 10 places with Projector",
                Capacity = 10,
                Office = context.Offices.FirstOrDefault(o => o.Name == "HR Office"),
                HallStatus = context.HallStatuses.FirstOrDefault(s => s.Name == "Active"),
                Items = context.Items.Where(i => i.Name == "Projector").ToList()
            };

            context.Halls.Add(seventhHall);

            var eighthHall = new Hall
            {
                Name = "Hall 8",
                Description = "Hall with 10 places with Projector",
                Capacity = 10,
                Office = context.Offices.FirstOrDefault(o => o.Name == "HR Office"),
                HallStatus = context.HallStatuses.FirstOrDefault(s => s.Name == "Active"),
                Items = context.Items.Where(i => i.Name == "Projector").ToList()
            };

            context.Halls.Add(eighthHall);

            var ninethHall = new Hall
            {
                Name = "Hall 9",
                Description = "Hall with 10 places with TV",
                Capacity = 10,
                Office = context.Offices.FirstOrDefault(o => o.Name == "HR Office"),
                HallStatus = context.HallStatuses.FirstOrDefault(s => s.Name == "Active"),
                Items = context.Items.Where(i => i.Name == "TV").ToList()
            };

            context.Halls.Add(ninethHall);

            var tenthHall = new Hall
            {
                Name = "Hall 10",
                Description = "Hall with 10 places with TV",
                Capacity = 10,
                Office = context.Offices.FirstOrDefault(o => o.Name == "HR Office"),
                HallStatus = context.HallStatuses.FirstOrDefault(s => s.Name == "Active"),
                Items = context.Items.Where(i => i.Name == "TV").ToList()
            };

            context.Halls.Add(tenthHall);

            context.SaveChanges();
        }
    }
}
