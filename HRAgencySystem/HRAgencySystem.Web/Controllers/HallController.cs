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
using HRAgencySystem.Models;
using HRAgencySystem.Web.ViewModels.Hall;
using Microsoft.AspNet.Identity;
using PagedList;

namespace HRAgencySystem.Web.Controllers
{
    public class HallController : BaseController
    {
        public HallController(IHRAgancyData data) 
            : base(data)
        {
        }

        [HttpGet]
        [Authorize]
        public ActionResult Details(int id)
        {
            var hall = this.Data.Halls
                .All()
                .Include(h => h.Items)
                .FirstOrDefault(h => h.Id == id);

            var hallDetailsViewModel = Mapper.Map<HallDetailsViewModel>(hall);

            return View(hallDetailsViewModel);
        }

        [HttpGet]
        [Authorize]
        public ActionResult ShowReservations(int id, int? page)
        {
            var getHallReservations = this.Data.Reservations
                .All()
                .Where(r => r.HallId == id)
                .OrderByDescending(r => r.StartDate)
                .ToList();

            List<HallReservationsViewModel> hallReservations= new List<HallReservationsViewModel>();
            foreach (var hallReservation in getHallReservations)
            {
                HallReservationsViewModel hallReservationVewModel = new HallReservationsViewModel
                {
                    Id = hallReservation.Id,
                    HallName = this.Data.Halls.All().Where(h => h.Id == hallReservation.HallId).Select(h => h.Name).FirstOrDefault(),
                    Description = hallReservation.Description,
                    CapacityForReservation = hallReservation.CapacityForReservation,
                    isUserInReservation = hallReservation.Users.FirstOrDefault(u => u.Id == User.Identity.GetUserId()) != null,
                    StartDate = hallReservation.StartDate,
                    EndDate = hallReservation.EndDate   
                };
                hallReservations.Add(hallReservationVewModel);
            }
            return View(hallReservations);
        }
    }
}