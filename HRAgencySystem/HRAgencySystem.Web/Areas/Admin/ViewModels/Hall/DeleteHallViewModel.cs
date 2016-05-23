using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HRAgencySystem.Web.ViewModels.Hall;
using HRAgencySystem.Web.ViewModels.Reservation;

namespace HRAgencySystem.Web.Areas.Admin.ViewModels.Hall
{
    public class DeleteHallViewModel
    {
        public HallDetailsViewModel Hall { get; set; }

        public IEnumerable<ReservationViewModel> Reservations { get; set; }
    }
}