using EasyHome2.Models;
using EasyHome2.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace EasyHome2.Controllers
{
    public class AdminController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();


        // GET: Admin
        public ActionResult Index()
        {
            AllCPIViewModel viewmodel = new AllCPIViewModel();
            viewmodel.AdCommercialProperty = db.AdCommercialProperty.ToList();
            viewmodel.AddCommercialTypeRental = db.AddCommercialTypeRental.ToList();
            viewmodel.AddHomeTypeRental = db.AddHomeTypeRental.ToList();
            viewmodel.AdHomeProperty = db.AdHomeProperty.ToList();
            viewmodel.AdPlotProperty = db.AdPlotProperty.ToList();
            viewmodel.PayingGuest = db.PayingGuest.ToList();
            return View(viewmodel);
        }

        public ActionResult Home()
        {
            var home = db.AdHomeProperty.ToList();

            return View(home);
        }

        public ActionResult HomeDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AllViewModel allViewModel = new AllViewModel();
            allViewModel.AdHomeProperty = db.AdHomeProperty.Find(id);
            allViewModel.HomeImages = db.HomeImages.Where(i => i.HomeId == id).ToList();
            return View(allViewModel);
        }
        public ActionResult HomeDelete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AllViewModel allViewModel = new AllViewModel();
            allViewModel.AdHomeProperty = db.AdHomeProperty.Find(id);
            allViewModel.HomeImages = db.HomeImages.Where(i => i.HomeId == id).ToList();
            if (allViewModel == null)
            {
                return HttpNotFound();
            }

            return View(allViewModel);
        }

        // POST: AdHomeProperties/Delete/5
        [HttpPost, ActionName("HomeDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AdHomeProperty adHomeProperty = db.AdHomeProperty.Find(id);
            db.HomeImages.Where(p => p.HomeId == adHomeProperty.Id).ToList().ForEach(c =>
            {
                db.HomeImages.Remove(c);
            });
            db.AdHomeProperty.Remove(adHomeProperty);
            db.SaveChanges();
            return RedirectToAction("Index", "Admin");

        }


        public ActionResult Commercial()
        {
            var Comm = db.AdCommercialProperty.ToList();

            return View(Comm);
        }


        public ActionResult CommercialDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            /* AdCommecialProperty adCommecialProperty = db.AdCommercialProperty.Find(id);
             if (adCommecialProperty == null)
             {
                 return HttpNotFound();
             }*/



            AllViewModel allViewModel = new AllViewModel();
            allViewModel.AdCommercialProperty = db.AdCommercialProperty.Find(id);
            allViewModel.CommercialImages = db.CommercialImages.Where(i => i.CommercialId == id).ToList();
            return View(allViewModel);
        }

        public ActionResult CommercialDelete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            // AdCommecialProperty adCommecialProperty = db.AdCommercialProperty.Find(id);

            AllViewModel allViewModel = new AllViewModel();

            allViewModel.AdCommercialProperty = db.AdCommercialProperty.Find(id);
            allViewModel.CommercialImages = db.CommercialImages.Where(i => i.CommercialId == id).ToList();
            if (allViewModel == null)
            {
                return HttpNotFound();
            }

            return View(allViewModel);
        }

        // POST: AdCommecialProperties/Delete/5
        [HttpPost, ActionName("CommercialDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult CommDeleteConfirmed(int id)
        {


            AdCommecialProperty adCommecialProperty = db.AdCommercialProperty.Find(id);
            db.CommercialImages.Where(p => p.CommercialId == adCommecialProperty.Id).ToList().ForEach(c =>
            {
                db.CommercialImages.Remove(c);
            });
            db.AdCommercialProperty.Remove(adCommecialProperty);
            db.SaveChanges();
            return RedirectToAction("Commercial", "Admin");
        }

        public ActionResult Plot()
        {
            var plot= db.AdPlotProperty.ToList();
        
            return View(plot);
        }
        public ActionResult PlotDetails(int? id)
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

        
        // GET: AdPlotProperties/Delete/5
        public ActionResult PlotDelete(int? id)
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
        [HttpPost, ActionName("PlotDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult PlotDeleteConfirmed(int id)
        {
            AdPlotProperty adPlotProperty = db.AdPlotProperty.Find(id);
            db.AdPlotProperty.Remove(adPlotProperty);
            db.SaveChanges();
            return RedirectToAction("Index");
        }



        public ActionResult CommercialRental()
        {
            var Comm = db.AddCommercialTypeRental.ToList();

            return View(Comm);
        }


        public ActionResult CommercialRentalDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            /* AdCommecialProperty adCommecialProperty = db.AdCommercialProperty.Find(id);
             if (adCommecialProperty == null)
             {
                 return HttpNotFound();
             }*/



            AllViewModel allViewModel = new AllViewModel();
            allViewModel.AddCommercialTypeRental = db.AddCommercialTypeRental.Find(id);
            allViewModel.RentalCommercialImages = db.RentalCommercialImages.Where(i => i.RentalCommercialId == id).ToList();
            return View(allViewModel);
        }

        public ActionResult CommercialRentalDelete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            // AdCommecialProperty adCommecialProperty = db.AdCommercialProperty.Find(id);

            AllViewModel allViewModel = new AllViewModel();

            allViewModel.AddCommercialTypeRental = db.AddCommercialTypeRental.Find(id);
            allViewModel.RentalCommercialImages = db.RentalCommercialImages.Where(i => i.RentalCommercialId == id).ToList();
            if (allViewModel == null)
            {
                return HttpNotFound();
            }

            return View(allViewModel);
        }

        // POST: AdCommecialProperties/Delete/5
        [HttpPost, ActionName("CommercialDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult CommRentalDeleteConfirmed(int id)
        {


            AddCommercialTypeRental adCommecialRentalProperty = db.AddCommercialTypeRental.Find(id);
            db.RentalCommercialImages.Where(p => p.RentalCommercialId == adCommecialRentalProperty.Id).ToList().ForEach(c =>
            {
                db.RentalCommercialImages.Remove(c);
            });
            db.AddCommercialTypeRental.Remove(adCommecialRentalProperty);
            db.SaveChanges();
            return RedirectToAction("CommercialRental", "Admin");
        }
    }
}


