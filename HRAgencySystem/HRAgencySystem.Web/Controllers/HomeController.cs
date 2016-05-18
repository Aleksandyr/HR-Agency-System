
using AutoMapper.QueryableExtensions;
using HRAgencySystem.Web.ViewModels.Hall;
using PagedList;

namespace HRAgencySystem.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using System.Collections.Generic;

    using AutoMapper;

    using HRAgencySystem.Web.ViewModels;
    using HRAgencySystem.Common;
    using HRAgencySystem.Data.DataLayer;

    public class HomeController : BaseController
    {
        public HomeController(IHRAgancyData data)
            : base(data)
        {
        }

        [AllowAnonymous]
        public ActionResult Index(int? page)
        {
            var halls = this.Data.Halls
                .All()
                .Where(h => h.HallStatus.Name == "Active")
                .OrderByDescending(h => h.Name)
                .ProjectTo<HallViewModel>()
                .ToPagedList(page ?? GlobalConstants.DefaultHallStartPage, GlobalConstants.DefaulHalltPageSize);

            return View(halls);
        }

        [AllowAnonymous]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [AllowAnonymous]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}