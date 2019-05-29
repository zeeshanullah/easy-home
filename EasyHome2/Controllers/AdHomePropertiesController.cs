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
using Microsoft.AspNet.Identity;
using GoogleMaps.LocationServices;

namespace EasyHome1.Controllers
{
    public class AdHomePropertiesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();


        // GET: AdHomeProperties
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
            avm.AdHomeProperty = db.AdHomeProperty.ToList();
            avm.HomeImages = db.HomeImages.ToList();
            ////return View(db.AdCommercialProperty.ToList());
            return View(avm);
        }

        // GET: AdHomeProperties/Details/5
        public ActionResult Details(int? id)
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

        // GET: AdHomeProperties/Create
        public ActionResult Create()
        {
            if (User.Identity.GetUserId() == null)
            {
                return RedirectToAction("Register", "Account");
            }
            var homeTypes = db.HomeType.ToList();
            var Viewmodel = new HomeViewModel
            {
                AdHomeProperty = new AdHomeProperty(),
                HomeTypes = homeTypes
            };

            
            return View(Viewmodel);
        }

        // POST: AdHomeProperties/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( AdHomeProperty adHomeProperty)
        {
            if (ModelState.IsValid)
            {
                var locationService = new GoogleLocationService();
                var point = locationService.GetLatLongFromAddress(adHomeProperty.Address);
                adHomeProperty.AddressLatitude = point.Latitude;
                adHomeProperty.AddressLongitude = point.Longitude;


                var userid = User.Identity.GetUserId();
                ApplicationUser currentuser = db.Users.FirstOrDefault(c => c.Id == userid);

                adHomeProperty.UserName = currentuser.UserName;
                adHomeProperty.UserEmail = currentuser.Email;
                adHomeProperty.PhoneNumber = currentuser.PhoneNumber;
                adHomeProperty.UserId = User.Identity.GetUserId();

                int cot = db.AdHomeProperty.OrderByDescending(o => o.Id).FirstOrDefault().HCount;
                adHomeProperty.HCount = cot + 1;
                db.AdHomeProperty.Add(adHomeProperty);
             
                db.SaveChanges();
                return RedirectToAction("Upload_Image",new { Id=adHomeProperty.Id});
            }

          
            return View(adHomeProperty);
        }

        // GET: AdHomeProperties/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdHomeProperty adHomeProperty = db.AdHomeProperty.Find(id);
            if (adHomeProperty == null)
            {
                return HttpNotFound();
            }
            return View(adHomeProperty);
        }

        // POST: AdHomeProperties/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,HomeTypeId,City,Location,PropertyTitle,PropertyDescription,PropertyPrice,PropertyLandArea,PropertyLandAreaUnit,Bedrooms,Bathrooms,BuiltinYear,ParkingSpaces,DiningRoom,DrawingRoom,Kitchens,ExpiresAfter,Address")] AdHomeProperty adHomeProperty)
        {
            if (ModelState.IsValid)
            {
                db.Entry(adHomeProperty).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(adHomeProperty);
        }

        // GET: AdHomeProperties/Delete/5
        public ActionResult Delete(int? id)
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
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AdHomeProperty adHomeProperty = db.AdHomeProperty.Find(id);
            db.AdHomeProperty.Remove(adHomeProperty);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

       /* protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }*/

        public ActionResult Upload_Image(int Id)
        {
            return View(new HomeImagesViewModel() { HomeId = Id });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Upload_Image(HomeImagesViewModel model)
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


                    var image = new HomeImages
                    {
                        Title = model.Caption,
                        AltText = model.Caption,
                        Caption = model.Caption,
                        HomeId = model.HomeId,
                        CreatedDate = DateTime.Now,
                        ImageNumber = imageNumber++
                    };
                    if (item != null && item.ContentLength > 0)
                    {
                        var uploadDir = "~/Uploads/";
                        var imagePath = Path.Combine(Server.MapPath(uploadDir), item.FileName);
                        var imageUrl = Path.Combine(uploadDir, item.FileName);
                        item.SaveAs(imagePath);
                        image.ImageUrl = imageUrl;

                    }

                    db.HomeImages.Add(image);
                }

                db.SaveChanges();
            }

            return RedirectToAction("Index", "Home");
        }
    }
}


