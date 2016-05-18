using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using HRAgencySystem.Data.DataLayer;
using HRAgencySystem.Web.ViewModels.Hall;

namespace HRAgencySystem.Web.Controllers
{
    public class HallController : BaseController
    {
        public HallController(IHRAgancyData data) 
            : base(data)
        {
        }

        public ActionResult Details(int id)
        {
            var hall = this.Data.Halls
                .All()
                .Include(h => h.Items)
                .FirstOrDefault(h => h.Id == id);

            var hallDetailsViewModel = Mapper.Map<HallDetailsViewModel>(hall);

            return View(hallDetailsViewModel);
        }
    }
}