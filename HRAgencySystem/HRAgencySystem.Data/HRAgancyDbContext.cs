using HRAgencySystem.Data.Migrations;

namespace HRAgencySystem.Data
{
    using System.Data.Entity;

    using Microsoft.AspNet.Identity.EntityFramework;
    
    using Models;

    public class HRAgancyDbContext : IdentityDbContext<User>
    {
        public HRAgancyDbContext()
            : base("HRAgancy", throwIfV1Schema: false)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<HRAgancyDbContext, Configuration>());
        }

        public virtual IDbSet<Hall> Halls { get; set; }

        public virtual IDbSet<HallStatus> HallStatuses { get; set; }

        public virtual IDbSet<Item> Items { get; set; }

        public virtual IDbSet<Office> Offices { get; set; }

        public virtual IDbSet<Reservation> Reservations { get; set; }


        public static HRAgancyDbContext Create()
        {
            return new HRAgancyDbContext();
        }
    }
}