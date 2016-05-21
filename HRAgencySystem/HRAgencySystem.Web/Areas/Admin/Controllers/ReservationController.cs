using System.Collections.Generic;
using AutoMapper;
using HRAgencySystem.Models;

namespace HRAgencySystem.Web.Areas.Admin.Controllers
{
    using System.Web.Mvc;
    using System.Linq;

    using HRAgencySystem.Data.DataLayer;
    using HRAgencySystem.Web.Areas.InputModels.Registration;
    using HRAgencySystem.Web.Controllers;

    [Authorize(Roles = "Admin")]
    [Route("Admin/Reservation")]
    public class ReservationController : BaseController
    {
        public ReservationController(IHRAgancyData data) 
            : base(data)
        {
        }

        [HttpGet]
        public ActionResult CreateReservation()
        {
            this.LoadHalls();
            this.LoadUsers();
            return View("~/Areas/Admin/Views/Reservation/CreateReservation.cshtml");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateReservation(ReservationInputModel model)
        {
            if (model != null && this.ModelState.IsValid)
            {
                var getHallReservations = this.Data.Reservations.All()
                    .Where(r => r.HallId == model.HallId);

                bool isHaveReservation = false;
                foreach (var hallReservation in getHallReservations)
                {
                    // Check is have reservation that is between input date of reservation
                    if ((model.StartDate <= hallReservation.StartDate && model.EndDate >= hallReservation.EndDate))
                    {
                        isHaveReservation = true;
                    }

                    // Check is input start date is detected with one of the dates and check if input end date is detected with one of the dates
                    if ((model.StartDate <= hallReservation.EndDate && model.StartDate >= hallReservation.StartDate) ||
                        (model.EndDate >= hallReservation.StartDate && model.EndDate <= hallReservation.EndDate))
                    {
                        isHaveReservation = true;
                    }
                }

                //You can reserve hall at least for an hour and check is have reservation
                if ((model.StartDate.AddHours(1) <= model.EndDate) && (!isHaveReservation))
                { 
                    List<User> users = new List<User>();
                    foreach (var userId in model.UserIds)
                    {
                        users.Add(this.Data.Users.All().FirstOrDefault(u => u.Id == userId));
                    }

                    var currentHall = this.Data.Halls.All().FirstOrDefault(h => h.Id == model.HallId);

                    //Check is have enough capacity for users;
                    bool isHaveCapacity = currentHall.Capacity >= users.Count();
                    if (isHaveCapacity)
                    {
                        var reservation = new Reservation
                        {
                            Description = model.Description,
                            HallId =
                                this.Data.Halls.All()
                                    .Where(h => h.Id == model.HallId)
                                    .Select(h => h.Id)
                                    .FirstOrDefault(),
                            Users = users,
                            StartDate = model.StartDate,
                            EndDate = model.EndDate,
                            CapacityForReservation = currentHall.Capacity - users.Count()
                        };

                        this.Data.Reservations.Add(reservation);
                        this.Data.SaveChanges();
                    }
                }

                return this.RedirectToRoute("Home/Index", new {area = ""});
            }

            //When we return model we will show the errors
            return this.View(model);
        }

        private void LoadHalls()
        {
            this.ViewBag.Halls = this.Data.Halls
                .All()
                .Select(x => new SelectListItem
                {
                    Value = x.Id.ToString(),
                    Text = x.Name
                });
        }

        private void LoadUsers()
        {
            this.ViewBag.Users = this.Data.Users
                .All()
                .Select(x => new SelectListItem
                {
                    Value = x.Id.ToString(),
                    Text = x.UserName
                });
        }
    }
}