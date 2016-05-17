using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HRAgencySystem.Data;
using HRAgencySystem.Data.DataLayer;

namespace HRAgencySystem.Web.Controllers
{
    public abstract class BaseController : Controller
    {
        protected BaseController(IHRAgancyData data)
        {
            this.Data = data;
        }

        protected IHRAgancyData Data { get; private set; }
    }
}