using AutoMapper;

namespace HRAgencySystem.Web.ViewModels.Reservation
{
    using System;
    using System.Collections.Generic;

    using HRAgencySystem.Common.Mappings;
    using HRAgencySystem.Web.ViewModels.User;
    using HRAgencySystem.Models;

    public class ReservationDetailsViewModel : IMapFrom<Reservation>
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public string HallName { get; set; }

        public int CapacityForReservation { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public bool isUserInReservation { get; set; }

        public IEnumerable<UserViewModel> Users { get; set; }
    }
}