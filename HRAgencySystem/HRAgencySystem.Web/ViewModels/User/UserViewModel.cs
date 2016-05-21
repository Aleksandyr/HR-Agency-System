using HRAgencySystem.Common.Mappings;

namespace HRAgencySystem.Web.ViewModels.User
{
    using HRAgencySystem.Models;

    public class UserViewModel : IMapFrom<User>
    {
        public string Id { get; set; }

        public string UserName { get; set; }
    }
}