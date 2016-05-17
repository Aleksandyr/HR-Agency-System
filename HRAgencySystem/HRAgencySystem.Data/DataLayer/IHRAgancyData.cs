using HRAgencySystem.Data.Repositories;
using HRAgencySystem.Models;

namespace HRAgencySystem.Data.DataLayer
{
    public interface IHRAgancyData
    {
        IRepository<User> Users { get; }

        IRepository<Hall> Halls { get; }

        IRepository<Item> Items { get; }

        IRepository<HallStatus> HallStatuses { get; }

        IRepository<Reservation> Reservations { get; }

        int SaveChanges();
    }
}
