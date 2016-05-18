using HRAgencySystem.Common.Mappings;

namespace HRAgencySystem.Web.ViewModels.User
{
    using HRAgencySystem.Models;

    public class UserViewModel : IMapFrom<User>
    {
        public int Id { get; set; }

        public string Username { get; set; }
    }
}