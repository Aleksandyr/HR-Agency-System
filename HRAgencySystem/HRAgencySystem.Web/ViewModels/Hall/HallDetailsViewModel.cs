namespace HRAgencySystem.Web.ViewModels.Hall
{
    using System.Collections.Generic;

    using AutoMapper;

    using HRAgencySystem.Web.ViewModels.Item;
    using HRAgencySystem.Common.Mappings;
    using HRAgencySystem.Models;

    public class HallDetailsViewModel : IMapFrom<Hall>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Capacity { get; set; }

        public string OfficeName { get; set; }

        public string HallStatusName { get; set; }

        public IEnumerable<ItemViewModel> Items { get; set; }
    }
}