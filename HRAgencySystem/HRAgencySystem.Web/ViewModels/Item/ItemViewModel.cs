namespace HRAgencySystem.Web.ViewModels.Item
{
    using HRAgencySystem.Common.Mappings;
    using HRAgencySystem.Models;

    public class ItemViewModel : IMapFrom<Item>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}