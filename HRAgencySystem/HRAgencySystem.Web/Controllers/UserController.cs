
using System.Net;
using AutoMapper.QueryableExtensions;
using HRAgencySystem.Web.ViewModels.Reservation;

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

                // Update reservation capacity
                int updatedCapacity = ++reservation.CapacityForReservation;
                reservation.CapacityForReservation = updatedCapacity;
                this.Data.Reservations.Update(reservation);

                this.Data.SaveChanges();

                return this.PartialView("Reservations", this.LoadUserReservation(currUserId));
            }

            return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Cannot delete the user!");
        }

        [HttpPost]
        public ActionResult AddMeToTheReservation(int id)
        {
            var currUserId = this.User.Identity.GetUserId();
            var currUser = this.Data.Users
                .All()
                .FirstOrDefault(u => u.Id == currUserId);

            var reservation = this.Data.Reservations
                .All()
                .FirstOrDefault(r => r.Id == id);

            bool isUserExistInReservation = reservation.Users.FirstOrDefault(r => r.Id == currUserId) != null;
            if (!isUserExistInReservation && currUser != null)
            {
                reservation.Users.Add(currUser);
                reservation.CapacityForReservation = --reservation.CapacityForReservation;

                this.Data.Reservations.Update(reservation);
                this.Data.SaveChanges();

                var reservationDetailsViewModel = Mapper.Map<ReservationDetailsViewModel>(reservation);

                return this.PartialView("PartialReservation", reservationDetailsViewModel);
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Cannot add me to this reservation!");
            }
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