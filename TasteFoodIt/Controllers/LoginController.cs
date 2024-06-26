﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using TasteFoodIt.Context;
using TasteFoodIt.Entities;

namespace TasteFoodIt.Controllers
{
	public class LoginController : Controller
	{
		TasteContext context = new TasteContext();

		[HttpGet]
		public ActionResult Index()
		{
			return View();
		}

		[HttpPost]
		public ActionResult Index(Admin p)
		{
			var values = context.Admins.FirstOrDefault(x => x.Username == p.Username && x.Password == p.Password);
			if (values != null)
			{
				FormsAuthentication.SetAuthCookie(values.Username, true);
				Session["a"] = values.Username;
				return RedirectToAction("Index", "Profile");
			}
			return View();
		}
	}
}