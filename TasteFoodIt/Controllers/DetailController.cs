﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TasteFoodIt.Context;

namespace TasteFoodIt.Controllers
{
    public class DetailController : Controller
    {
        TasteContext context = new TasteContext();
        public ActionResult About()
        {
            ViewBag.pageName = "Hakkımızda";
            ViewBag.reservationCount = context.Reservations.Count();
            ViewBag.chefsCount = context.Chefs.Count();
            ViewBag.productCount = context.Products.Count();
            ViewBag.testimonialCount = context.Testimonials.Count();
            return View();
        }

        public ActionResult Chef()
        {
            ViewBag.pageName = "Şeflerimiz";
            var chef = context.Chefs.ToList();
            return View(chef);
        }

        public ActionResult Menu()
        {
            ViewBag.pageName = "Menü";
            var menu = context.Products.ToList();
            return View(menu);
        }

        public ActionResult Reservation()
        {
            ViewBag.pageName = "Rezervasyon";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.pageName = "İletişim";
            ViewBag.email = context.Adresses.Select(x => x.Email).FirstOrDefault();
            ViewBag.phone = context.Adresses.Select(x => x.Phone).FirstOrDefault();
            ViewBag.description = context.Adresses.Select(x => x.Description).FirstOrDefault();
            return View();
        }
    }
}