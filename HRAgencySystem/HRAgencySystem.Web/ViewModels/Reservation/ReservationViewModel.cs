namespace HRAgencySystem.Web.ViewModels.Reservation
{
    using HRAgencySystem.Models;
    using HRAgencySystem.Common.Mappings;


    public class ReservationViewModel : IMapFrom<Reservation>
    {
        public int Id { get; set; }

        public string HallName { get; set; }

        public string Description { get; set; }

        public int CapacityForReservation { get; set; }
    }
}