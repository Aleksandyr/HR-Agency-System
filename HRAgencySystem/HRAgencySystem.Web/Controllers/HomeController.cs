using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HRAgencySystem.Data.DataLayer;

namespace HRAgencySystem.Web.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController(IHRAgancyData data)
            : base(data)
        {
        }

        public ActionResult Index()
        {
            Console.WriteLine();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}