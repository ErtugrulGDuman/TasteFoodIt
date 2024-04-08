﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TasteFoodIt.Context;
using TasteFoodIt.Entities;

namespace TasteFoodIt.Controllers
{
    public class DashboardController : Controller
    {
        TasteContext context = new TasteContext();
        public ActionResult Index()
        {
            ViewBag.v1 = context.Categories.Count();
            ViewBag.v2 = context.Products.Count();
            ViewBag.v3 = context.Chefs.Count();
            ViewBag.v4 = context.Reservations.Where(x => x.ReservationStatus == "Aktif").Count();
            return View();
        }

    }
}