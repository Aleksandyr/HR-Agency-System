namespace HRAgencySystem.Web.ViewModels.User
{
    using System;

    using HRAgencySystem.Common.Mappings;
    using HRAgencySystem.Models;

    public class UserReservationsViewModel : IMapFrom<Reservation>
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public string HallName { get; set; }

        public int CapacityForReservation { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
    }
}