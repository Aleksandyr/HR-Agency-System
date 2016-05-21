using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using HRAgencySystem.Common;
using HRAgencySystem.Data.DataLayer;
using HRAgencySystem.Web.ViewModels.Reservation;
using HRAgencySystem.Web.ViewModels.User;
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
            string startDate = this.Request.QueryString["startDate"];
            string endDate = this.Request.QueryString["endDate"];
            var getAllReservations = new PagedList<ReservationViewModel>(null, page ?? GlobalConstants.DefaultReservationsStartPage,
                        GlobalConstants.DefaulReservationstPageSize);

            DateTime startDateToDateTime = new DateTime();
            DateTime endDateToDateTime = new DateTime();

            if (!string.IsNullOrEmpty(startDate) && !string.IsNullOrEmpty(endDate))
            {
                startDateToDateTime = DateTime.Parse(startDate);
                endDateToDateTime = DateTime.Parse(endDate);

                if (startDateToDateTime < endDateToDateTime)
                {

                    getAllReservations = (PagedList<ReservationViewModel>) this.Data.Reservations
                        .All()
                        .Where(r => r.StartDate >= startDateToDateTime && r.EndDate <= endDateToDateTime)
                        .OrderBy(r => r.StartDate)
                        .ProjectTo<ReservationViewModel>()
                        .ToPagedList(page ?? GlobalConstants.DefaultReservationsStartPage,
                            GlobalConstants.DefaulReservationstPageSize);
                }
            }
            else if (!string.IsNullOrEmpty(startDate))
            {
                startDateToDateTime = DateTime.Parse(startDate);

                getAllReservations = (PagedList<ReservationViewModel>)this.Data.Reservations
                        .All()
                        .Where(r => r.StartDate >= startDateToDateTime)
                        .OrderBy(r => r.StartDate)
                        .ProjectTo<ReservationViewModel>()
                        .ToPagedList(page ?? GlobalConstants.DefaultReservationsStartPage,
                            GlobalConstants.DefaulReservationstPageSize);
            }
            else if (!string.IsNullOrEmpty(endDate))
            {
                endDateToDateTime = DateTime.Parse(endDate);

                getAllReservations = (PagedList<ReservationViewModel>)this.Data.Reservations
                        .All()
                        .Where(r => r.EndDate <= endDateToDateTime)
                        .OrderBy(r => r.StartDate)
                        .ProjectTo<ReservationViewModel>()
                        .ToPagedList(page ?? GlobalConstants.DefaultReservationsStartPage,
                            GlobalConstants.DefaulReservationstPageSize);
            }
            else
            {
                getAllReservations = (PagedList<ReservationViewModel>) this.Data.Reservations
                    .All()
                    .OrderBy(r => r.StartDate)
                    .ProjectTo<ReservationViewModel>()
                    .ToPagedList(page ?? GlobalConstants.DefaultReservationsStartPage,
                        GlobalConstants.DefaulReservationstPageSize);
            }

            return View(getAllReservations);
        }

        public ActionResult Details(int id)
        {
            var reservation = this.Data.Reservations
                .All()
                .Include(r => r.Users)
                .FirstOrDefault(r => r.Id == id);

            //var reservationDetailsViewModel = new ReservationDetailsViewModel()
            //{
            //    Description = reservation.Description,
            //    HallName = this.Data.Halls.All().Where(h => h.Id == reservation.HallId).Select(r => r.Name).FirstOrDefault(),
            //    CapacityForReservation = reservation.CapacityForReservation,
            //    StartDate = reservation.StartDate,
            //    EndDate = reservation.EndDate,
            //    Users = (IEnumerable<UserViewModel>) reservation.Users
            //};

            var reservationDetailsViewModel = Mapper.Map<ReservationDetailsViewModel>(reservation);

            return View(reservationDetailsViewModel);
        }
    }
}