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
            return View(model);
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