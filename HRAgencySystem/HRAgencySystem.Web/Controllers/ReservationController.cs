using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper.QueryableExtensions;
using HRAgencySystem.Common;
using HRAgencySystem.Data.DataLayer;
using HRAgencySystem.Web.ViewModels.Reservation;
using PagedList;

namespace HRAgencySystem.Web.Controllers
{
    public class ReservationController : BaseController
    {
        public ReservationController(IHRAgancyData data) 
            : base(data)
        {
        }

        // GET: Reservation
        public ActionResult AllReservations(int? page)
        {
            var getAllReservations = this.Data.Reservations
                .All()
                .OrderBy(r => r.StartDate)
                .ProjectTo<ReservationViewModel>()
                .ToPagedList(page ?? GlobalConstants.DefaultReservationsStartPage, GlobalConstants.DefaulReservationstPageSize);

            return View(getAllReservations);
        }
    }
}