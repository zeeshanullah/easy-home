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
using System.IO;
using EasyHome2.ViewModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using Microsoft.AspNet.Identity;
using GoogleMaps.LocationServices;
using Microsoft.AspNet.Identity.EntityFramework;

namespace EasyHome2.Controllers
{
    public class AdCommecialPropertiesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: AdCommecialProperties
        public ActionResult Index()
        {
            AllCPIViewModel avm = new AllCPIViewModel();
            /*  var list = db.AdCommercialProperty
                 .Join(db.CommercialImages,
                       p => p.Id,
                       e => e.CommercialId,
                       (p, e) => new 
                       {
                           AdCommercialProperty =p ,
                           CommercialImages=e
                       }
                       ).ToList();*/
            avm.AdCommercialProperty = db.AdCommercialProperty.ToList();
            avm.CommercialImages = db.CommercialImages.ToList();
            ////return View(db.AdCommercialProperty.ToList());
            return View(avm);
        }

        // GET: AdCommecialProperties/Details/5
        public ActionResult Details(int? id)
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

        // GET: AdCommecialProperties/Create
        public ActionResult Create()
        {
            if(User.Identity.GetUserId() == null)
            {
                return RedirectToAction("Register", "Account");
            }

            var Commercialtypes = db.CommercialTypes.ToList();
            var Viewmodel = new CommercialViewModel
            {
                AdCommecialProperty = new AdCommecialProperty(),
                CommercialTypes = Commercialtypes
            };

            return View(Viewmodel);
        }

        // POST: AdCommecialProperties/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CommercialTypeId,City,Location,PropertyTitle,PropertyDescription,PropertyPrice,PropertyLandArea,PropertyLandAreaUnit,BuiltinYear,Bathrooms,ExpiresAfter,Address")] AdCommecialProperty adCommecialProperty)
        {

            //var address = "75 Ninth Avenue 2nd and 4th Floors New York, NY 10011";
            //var locationService = new GoogleLocationService();
            //var point = locationService.GetLatLongFromAddress(address);
            //var latitude = point.Latitude;
            //var longitude = point.Longitude;

            if (ModelState.IsValid)
            {
                var locationService = new GoogleLocationService();
                var point = locationService.GetLatLongFromAddress(adCommecialProperty.Address);
                adCommecialProperty.AddressLatitude = point.Latitude;
                adCommecialProperty.AddressLongitude = point.Longitude;

                var userid = User.Identity.GetUserId();
                ApplicationUser currentuser = db.Users.FirstOrDefault(c => c.Id == userid);
                adCommecialProperty.UserId = User.Identity.GetUserId();
                adCommecialProperty.UserName = currentuser.UserName;
                adCommecialProperty.UserEmail = currentuser.Email;
                adCommecialProperty.PhoneNumber = currentuser.PhoneNumber;
                int cot = db.AdCommercialProperty.OrderByDescending(o=>o.Id).FirstOrDefault().Count;
                adCommecialProperty.Count = cot+1;
                db.AdCommercialProperty.Add(adCommecialProperty);
                db.SaveChanges();
                return RedirectToAction("Upload_Image", new { Id = adCommecialProperty.Id });
            }

            return View(adCommecialProperty);
        }

        // GET: AdCommecialProperties/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }


            //AllViewModel allViewModel = new AllViewModel();
            //allViewModel.AdCommercialProperty = db.AdCommercialProperty.Find(id);
            //allViewModel.CommercialImages = db.CommercialImages.Where(i => i.CommercialId == id).ToList();
            AdCommecialProperty adCommecialProperty = db.AdCommercialProperty.Find(id);

            if (adCommecialProperty == null)
            {
                return HttpNotFound();
            }
            return View(adCommecialProperty);
        }

        // POST: AdCommecialProperties/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CommercialTypeId,City,Location,PropertyTitle,PropertyDescription,PropertyPrice,PropertyLandArea,PropertyLandAreaUnit,BuiltinYear,Bathrooms,ExpiresAfter")] AdCommecialProperty adCommecialProperty)
        {
            if (ModelState.IsValid)
            {
                db.Entry(adCommecialProperty).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(adCommecialProperty);
        }

        // GET: AdCommecialProperties/Delete/5
        public ActionResult Delete(int? id)
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
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {


            AdCommecialProperty adCommecialProperty = db.AdCommercialProperty.Find(id);
            db.CommercialImages.Where(p => p.CommercialId == adCommecialProperty.Id).ToList().ForEach(c =>
            {
                db.CommercialImages.Remove(c);
            });
            db.AdCommercialProperty.Remove(adCommecialProperty);
            db.SaveChanges();
            return RedirectToAction("Index", "MyProperties");
        }

        /*protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }*/

        public ActionResult Upload_Image(int Id)
        {
            return View(new CommercialImagesViewModel() { CommercialId = Id });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Upload_Image(CommercialImagesViewModel model)
        {
            var ImageTypes = new string[]
            {
        "image/gif",
        "image/jpeg",
        "image/pjpeg",
        "image/png"
            };

            if (model.ImageUpload == null || model.ImageUpload.Count == 0)
            {
                ModelState.AddModelError("ImageUpload", "This field is required");
            }
            else if (model.ImageUpload.Where(p => ImageTypes.Contains(p.ContentType)).Count() == 0)
            {
                ModelState.AddModelError("ImageUpload", "Please choose either a GIF, JPG or PNG image.");
            }

            if (ModelState.IsValid)
            {
                var imageNumber = 0;

                foreach (var item in model.ImageUpload)
                {
                    imageNumber++;


                    var image = new CommercialImages
                    {
                        Title = model.Caption,
                        AltText = model.Caption,
                        Caption = model.Caption,
                        CommercialId=model.CommercialId,
                        CreatedDate = DateTime.Now,
                        ImageNumber = imageNumber
                    };
                    if (item != null && item.ContentLength > 0)
                    {
                        var uploadDir = "~/CommercialUploads/";
                        var imagePath = Path.Combine(Server.MapPath(uploadDir), item.FileName);
                        var imageUrl = Path.Combine(uploadDir, item.FileName);
                        item.SaveAs(imagePath);
                        image.ImageUrl = imageUrl;
                    }

                    db.CommercialImages.Add(image);
                }

                db.SaveChanges();
            }

            return RedirectToAction("Index", "Home");
        }
      }
}
