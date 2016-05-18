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
                if(model.StartDate < model.EndDate)
                { 
                    List<User> users = new List<User>();
                    foreach (var userId in model.UserIds)
                    {
                        users.Add(this.Data.Users.All().FirstOrDefault(u => u.Id == userId));
                    }

                    var reservation = new Reservation
                    {
                        Description = model.Description,
                        HallId = this.Data.Halls.All().Where(h => h.Id == model.HallId).Select(h => h.Id).FirstOrDefault(),
                        Users = users,
                        StartDate = model.StartDate,
                        EndDate = model.EndDate
                    };

                    this.Data.Reservations.Add(reservation);
                    this.Data.SaveChanges();
                }

                return this.RedirectToAction("Index", "Home");
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