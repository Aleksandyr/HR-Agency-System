using System.Data.Entity;
using System.Reflection.Emit;
using HRAgencySystem.Models;

namespace HRAgencySystem.Data
{
    public interface IHRAgancyDbContext
    {
        IDbSet<Hall> Halls { get; set; }

        IDbSet<HallStatus> HallStatuses { get; set; }

        IDbSet<Item> Items { get; set; }

        IDbSet<Office> Offices { get; set; }

        IDbSet<Reservation> Reservations { get; set; }

        int SaveChanges();
    }
}
