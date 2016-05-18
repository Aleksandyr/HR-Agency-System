using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HRAgencySystem.Common.Mappings;
using HRAgencySystem.Models;

namespace HRAgencySystem.Web.ViewModels.Hall
{
    public class HallReservationsViewModel : IMapFrom<Reservation>
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public string HallName { get; set; }

        public int CapacityForReservation { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
    }
}