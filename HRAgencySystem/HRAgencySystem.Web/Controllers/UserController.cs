
namespace HRAgencySystem.Web.Controllers
{
    using System.Web.Mvc;
    using System.Collections.Generic;
    using System.Linq;

    using AutoMapper;

    using HRAgencySystem.Data.DataLayer;
    using HRAgencySystem.Web.ViewModels.User;
    using Microsoft.AspNet.Identity;

    [Authorize]
    public class UserController : BaseController
    {
        public UserController(IHRAgancyData data) 
            : base(data)
        {
        }

        [HttpGet]
        public ActionResult Reservations()
        {
            var currUserId = User.Identity.GetUserId();
            var userReservations = this.Data.Users
                .All()
                .FirstOrDefault(u => u.Id == currUserId)
                .Reservations
                .OrderByDescending(r => r.StartDate)
                .ToList();

            var userReservationsViewModel = Mapper.Map<List<UserReservationsViewModel>>(userReservations);

            return View(userReservationsViewModel);
        }
    }
}