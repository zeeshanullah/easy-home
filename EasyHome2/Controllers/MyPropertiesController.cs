using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using EasyHome2.ViewModels;
using EasyHome2.Models;


namespace EasyHome2.Controllers
{
    public class MyPropertiesController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();

        // GET: MyProperties
        public ActionResult SellHomes()
        {
            return View();
        }

        public ActionResult Inbox()
        {
            if (User.Identity.GetUserId() == null)
            {
                return RedirectToAction("Register", "Account");
            }
            return View();
        }

        public ActionResult Index()
        {
            if (User.Identity.GetUserId() == null)
            {
                return RedirectToAction("Register", "Account");
            }

            var userId=User.Identity.GetUserId();
            AvmViewModel avm = new AvmViewModel();
            avm.AdCommercialProperty = db.AdCommercialProperty.Where(i => i.UserId == userId).ToList();
            if (avm.AdCommercialProperty != null)
            {
                avm.AdCommercialProperty.ForEach(prop =>
                {
                    prop.CommercialImages = db.CommercialImages.Where(img => img.CommercialId == prop.Id).ToList();
                });
            }
            avm.AddCommercialTypeRental = db.AddCommercialTypeRental.Where(i => i.UserId == userId).ToList();
            if (avm.AddCommercialTypeRental != null)
            {
                avm.AddCommercialTypeRental.ForEach(prop =>
                {
                    prop.RentalCommercialImages = db.RentalCommercialImages.Where(img => img.RentalCommercialId == prop.Id).ToList();
                });
            }
            avm.AddHomeTypeRental = db.AddHomeTypeRental.Where(i => i.UserId == userId).ToList();
            if (avm.AddHomeTypeRental != null)
            {
                avm.AddHomeTypeRental.ForEach(prop =>
                {
                    prop.RentalHomeImages = db.RentalHomeImages.Where(img => img.RentalHomeId == prop.Id).ToList();
                });
            }
            avm.AdHomeProperty = db.AdHomeProperty.Where(i => i.UserId == userId).ToList();
            if (avm.AdHomeProperty != null)
            {
                avm.AdHomeProperty.ForEach(prop =>
                {
                    prop.HomeImages = db.HomeImages.Where(img => img.HomeId == prop.Id).ToList();
                });
            }
            avm.AdPlotProperty = db.AdPlotProperty.Where(i => i.UserId == userId).ToList();
            avm.PayingGuest = db.PayingGuest.Where(i => i.UserId == userId).ToList();
            if (avm.PayingGuest != null)
            {
                avm.PayingGuest.ForEach(prop =>
                {
                    prop.PayingGuestImages = db.PayingGuestImages.Where(img => img.PayingGuestId == prop.Id).ToList();
                });
            }

            //var CPID = db.AdCommercialProperty.Where(i => i.UserId == userID).Select(u => new { Id = u.UserId }).ToList();
            //avm.commercialImages = db.CommercialImages.Where(i => i.CommercialId == CPID.)
            //avm.commercialImages = db.AdCommercialProperty
            //    .Join(db.CommercialImages,
            //    p => p.Id,
            //    e => e.CommercialId,
            //    (p, e)=>new CommercialImages
            //    {
            //        ImageUrl=e.ImageUrl,
            //        Caption=e.Caption,
            //        AltText=e.AltText,
            //        Title=e.Title

            //    }

            //    ).ToList();

            return View("Index", avm);
        }
        public ActionResult SellCommercials()
        {
            var userID = User.Identity.GetUserId();
            AllCPIViewModel avm = new AllCPIViewModel();
            //avm.adCommercialProperty = db.AdCommercialProperty.Where(i => i.UserId == userID).ToList();
            
            //var CPID = db.AdCommercialProperty.Where(i => i.UserId == userID).Select(u => new { Id = u.UserId }).ToList();
            //avm.commercialImages = db.CommercialImages.Where(i => i.CommercialId == CPID.)
            //avm.commercialImages = db.AdCommercialProperty
            //    .Join(db.CommercialImages,
            //    p => p.Id,
            //    e => e.CommercialId,
            //    (p, e)=>new CommercialImages
            //    {
            //        ImageUrl=e.ImageUrl,
            //        Caption=e.Caption,
            //        AltText=e.AltText,
            //        Title=e.Title

            //    }

            //    ).ToList();

            return View("Index",avm);
        }

        public ActionResult SellPlots()
        {
            return View();
        }

        public ActionResult RentalHomes()
        {
            return View();
        }

        public ActionResult RentalCommercials()
        {
            return View();
        }
        
    }
}