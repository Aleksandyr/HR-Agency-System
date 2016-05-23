namespace HRAgencySystem.Web.Areas.Admin.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    using System.Net;
    using AutoMapper.QueryableExtensions;

    using HRAgencySystem.Data.DataLayer;
    using HRAgencySystem.Models;
    using HRAgencySystem.Web.Areas.Admin.InputModels.Hall;
    using HRAgencySystem.Web.Areas.Admin.ViewModels.Hall;
    using HRAgencySystem.Web.Controllers;
    using HRAgencySystem.Web.ViewModels.Hall;
    using HRAgencySystem.Web.ViewModels.Reservation;

    [Authorize(Roles = "Admin")]
    [Route("Admin/Hall")]
    public class AdminHallController : BaseController
    {
        public AdminHallController(IHRAgancyData data) 
            : base(data)
        {
        }

        [HttpGet]
        public ActionResult Add()
        {
            this.LoadItems();
            this.LoadOffices();
            this.LoadStatuses();

            return View();
        }

        [HttpPost]
        public ActionResult Add(HallInputModel model)
        {
            var isHaveHallWithSameName = this.Data.Halls.All().FirstOrDefault(h => h.Name == model.Name) != null;
            if (model != null && this.ModelState.IsValid && !isHaveHallWithSameName)
            {
                List<Item> items = new List<Item>();
                foreach (var itemId in model.ItemIds)
                {
                    items.Add(this.Data.Items.All().FirstOrDefault(i => i.Id == itemId));
                }

                var hall = new Hall()
                {
                    Name = model.Name,
                    Description = model.Description,
                    OfficeId = this.Data.Offices.All().Where(o => o.Id == model.OfficeId).Select(o => o.Id).FirstOrDefault(),
                    Capacity = model.Capacity,
                    HallStatusId = this.Data.HallStatuses.All().Where(s => s.Id == model.HallStatusId).Select(s => s.Id).FirstOrDefault(),
                    Items = items
                };

                this.Data.Halls.Add(hall);
                this.Data.SaveChanges();
            }

            return this.RedirectToAction("Index", "Home", new { area = ""});
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var hall = this.Data.Halls
                .All()
                .ProjectTo<HallDetailsViewModel>()
                .FirstOrDefault(h => h.Id == id);

            var reservaitons = this.Data.Reservations
               .All()
               .Where(r => r.HallId == id)
               .ProjectTo<ReservationViewModel>()
               .ToList();

            this.LoadItems();

            var model = new DeleteHallViewModel()
            {
                Hall = hall,
                Reservations = reservaitons
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult DeleteHall(int id)
        {
            var hall = this.Data.Halls
               .All()
               .FirstOrDefault(h => h.Id == id);

            var reservaitons = this.Data.Reservations
               .All()
               .Where(r => r.HallId == id)
               .ToList();

            if (hall != null)
            {
                if (reservaitons.Any())
                {
                    foreach (var reservation in reservaitons)
                    {
                        this.Data.Reservations.Delete(reservation);
                    }
                }

                this.Data.Halls.Delete(hall);
                this.Data.SaveChanges();

                return this.RedirectToAction("Index", "Home", new { area = "" });
            }

            return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Cannot delete this hall!");
        }

        private void LoadItems()
        {
            this.ViewBag.Items = this.Data.Items
                .All()
                .Select(x => new SelectListItem
                {
                    Value = x.Id.ToString(),
                    Text = x.Name
                });
        }

        private void LoadOffices()
        {
            this.ViewBag.Offices = this.Data.Offices
                .All()
                .Select(x => new SelectListItem
                {
                    Value = x.Id.ToString(),
                    Text = x.Name
                });
        }

        private void LoadStatuses()
        {
            this.ViewBag.Statuses = this.Data.HallStatuses
                .All()
                .Select(x => new SelectListItem
                {
                    Value = x.Id.ToString(),
                    Text = x.Name
                });
        }
    }
}