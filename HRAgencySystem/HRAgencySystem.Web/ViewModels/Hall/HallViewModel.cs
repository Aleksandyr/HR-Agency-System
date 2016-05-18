namespace HRAgencySystem.Web.ViewModels.Hall
{
    using Common.Mappings;
    using HRAgencySystem.Models;

    public class HallViewModel : IMapFrom<Hall>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Capacity { get; set; }
    }
}