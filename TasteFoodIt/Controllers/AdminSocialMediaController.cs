﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TasteFoodIt.Context;
using TasteFoodIt.Entities;

namespace TasteFoodIt.Controllers
{
    public class AdminSocialMediaController : Controller
    {
        TasteContext context = new TasteContext();

        public ActionResult SocialMediaList()
        {
            ViewBag.name = "Sosyal Medya";
            var value = context.SocialMedias.ToList();
            return View(value);
        }

        [HttpGet]
        public ActionResult CreateSocialMedia()
        {
            ViewBag.name = "Sosyal Medya";
            return View();
        }
        [HttpPost]
        public ActionResult CreateSocialMedia(SocialMedia socialMedia)
        {
            socialMedia.Status = true;
            context.SocialMedias.Add(socialMedia);
            context.SaveChanges();
            return RedirectToAction("SocialMediaList");
        }

        [HttpGet]
        public ActionResult UpdateSocialMedia(int id)
        {
            ViewBag.name = "Sosyal Medya";
            var value = context.SocialMedias.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateSocialMedia(SocialMedia socialMedia)
        {
            var value = context.SocialMedias.Find(socialMedia.SocialMediaId);
            value.PlatformName = socialMedia.PlatformName;
            value.IconUrl = socialMedia.IconUrl;
            value.RedirectUrl = socialMedia.RedirectUrl;
            value.Status = socialMedia.Status;
            context.SaveChanges();
            return RedirectToAction("SocialMediaList");
        }

        public ActionResult DeleteSocialMedia(int id)
        {
            var value = context.SocialMedias.Find(id);
            context.SocialMedias.Remove(value);
            context.SaveChanges();
            return RedirectToAction("SocialMediaList");
        }

        public ActionResult StatusChangeSocialMedia(int id)
        {
            var value = context.SocialMedias.Find(id);
            if (value.Status == true)
            {
                value.Status = false;
            }
            else
            {
                value.Status = true;
            }
            context.SaveChanges();
            return RedirectToAction("SocialMediaList");
        }
    }
}