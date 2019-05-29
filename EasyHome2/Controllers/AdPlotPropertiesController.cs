using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EasyHome2.Models;
using EasyHome2.ViewModels;
using Microsoft.AspNet.Identity;
using GoogleMaps.LocationServices;

namespace EasyHome2.Controllers
{
    public class AdPlotPropertiesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: AdPlotProperties
        public ActionResult Index()
        {
            AllViewModel avm = new AllViewModel();
            avm.AdPlotProperty = db.AdPlotProperty.ToList();
            return View(avm);
        }

        // GET: AdPlotProperties/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlotViewModel adplotproperrty = new PlotViewModel();
            adplotproperrty.AdPlotProperty = db.AdPlotProperty.Find(id);
            if (adplotproperrty == null)
            {
                return HttpNotFound();
            }
            return View(adplotproperrty);
        }

        // GET: AdPlotProperties/Create
        public ActionResult Create()
        {
            if (User.Identity.GetUserId() == null)
            {
                return RedirectToAction("Register", "Account");
            }
            var Plottype = db.PlotType.ToList();
            var viewModel = new PlotViewModel
            {
                AdPlotProperty = new AdPlotProperty(),
                PlotTypes = Plottype
            };
            return View(viewModel);
        }

        // POST: AdPlotProperties/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,PlotTypeId,City,Location,Address,PropertyTitle,PropertyDescription,PropertyPrice,PropertyLandArea,PropertyLandAreaUnit,ExpiresAfter")] AdPlotProperty adPlotProperty)
        {
            if (ModelState.IsValid)
            {
                var locationService = new GoogleLocationService();
                var point = locationService.GetLatLongFromAddress(adPlotProperty.Address);
                adPlotProperty.AddressLatitude = point.Latitude;
                adPlotProperty.AddressLongitude = point.Longitude;


                var userid = User.Identity.GetUserId();
                ApplicationUser currentuser = db.Users.FirstOrDefault(c => c.Id == userid);

                adPlotProperty.UserName = currentuser.UserName;
                adPlotProperty.UserEmail = currentuser.Email;
                adPlotProperty.PhoneNumber = currentuser.PhoneNumber;
                adPlotProperty.UserId = User.Identity.GetUserId();
                db.AdPlotProperty.Add(adPlotProperty);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(adPlotProperty);
        }

        // GET: AdPlotProperties/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdPlotProperty adPlotProperty = db.AdPlotProperty.Find(id);
            if (adPlotProperty == null)
            {
                return HttpNotFound();
            }
            return View(adPlotProperty);
        }

        // POST: AdPlotProperties/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,PlotTypeId,City,Location,PropertyTitle,PropertyDescription,PropertyPrice,PropertyLandArea,PropertyLandAreaUnit,ExpiresAfter,Address")] AdPlotProperty adPlotProperty)
        {
            if (ModelState.IsValid)
            {
                db.Entry(adPlotProperty).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(adPlotProperty);
        }

        // GET: AdPlotProperties/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdPlotProperty adPlotProperty = db.AdPlotProperty.Find(id);
            if (adPlotProperty == null)
            {
                return HttpNotFound();
            }
            return View(adPlotProperty);
        }

        // POST: AdPlotProperties/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AdPlotProperty adPlotProperty = db.AdPlotProperty.Find(id);
            db.AdPlotProperty.Remove(adPlotProperty);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
