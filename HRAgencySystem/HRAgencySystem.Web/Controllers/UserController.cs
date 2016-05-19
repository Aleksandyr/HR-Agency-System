
using System.Net;

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

            return View(this.LoadUserReservation(currUserId));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteMeFromReservation(int id)
        {
            var currUserId = User.Identity.GetUserId();
            var currUser = this.Data.Users
                .All()
                .FirstOrDefault(x => x.Id == currUserId);

            var reservation = this.Data.Reservations
                .All()
                .FirstOrDefault(r => r.Id == id);

            if (currUser != null && reservation != null)
            {
                currUser.Reservations.Remove(reservation);
                this.Data.Users.Update(currUser);
                this.Data.SaveChanges();

                return this.View("Reservations", this.LoadUserReservation(currUserId));
            }

            return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Cannot delete the user!");
        }

        private List<UserReservationsViewModel> LoadUserReservation(string userId)
        {
            var userReservations = this.Data.Users
                    .All()
                    .FirstOrDefault(u => u.Id == userId)
                    .Reservations
                    .OrderByDescending(r => r.StartDate)
                    .ToList();

            return  Mapper.Map<List<UserReservationsViewModel>>(userReservations);
        } 
    }
}