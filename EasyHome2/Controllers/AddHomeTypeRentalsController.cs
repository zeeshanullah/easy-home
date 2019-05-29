using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EasyHome2.Models;
using System.IO;
using EasyHome2.ViewModels;
using Microsoft.AspNet.Identity;
using GoogleMaps.LocationServices;

namespace EasyHome2.Controllers
{
    public class AddHomeTypeRentalsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: AddHomeTypeRentals
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
            avm.AddHomeTypeRental = db.AddHomeTypeRental.ToList();
            avm.RentalHomeImages = db.RentalHomeImages.ToList();
            ////return View(db.AdCommercialProperty.ToList());
            return View(avm);
        }

        // GET: AddHomeTypeRentals/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AllViewModel allViewModel = new AllViewModel();
            allViewModel.AddHomeTypeRental = db.AddHomeTypeRental.Find(id);
            allViewModel.RentalHomeImages = db.RentalHomeImages.Where(i => i.RentalHomeId == id).ToList();
            return View(allViewModel);
        }

        // GET: AddHomeTypeRentals/Create
        public ActionResult Create()
        {
            if (User.Identity.GetUserId() == null)
            {
                return RedirectToAction("Register", "Account");
            }
            var hometypes = db.HomeType.ToList();
            var viewmodel = new HomeViewModel
            {
                AddHomeTypeRental = new AddHomeTypeRental(),
                HomeTypes = hometypes
            };
            return View(viewmodel);
        }

        // POST: AddHomeTypeRentals/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,RentalHomeType,City,Location,PropertyTitle,PropertyDescription,PropertyPrice,PropertyLandArea,PropertyLandAreaUnit,Bedrooms,Bathrooms,BuiltinYear,ParkingSpaces,DiningRoom,DrawingRoom,Kitchens,ExpiresAfter,Address")] AddHomeTypeRental addHomeTypeRental)
        {
            if (ModelState.IsValid)
            {
                var locationService = new GoogleLocationService();
                var point = locationService.GetLatLongFromAddress(addHomeTypeRental.Address);
                addHomeTypeRental.AddressLatitude = point.Latitude;
                addHomeTypeRental.AddressLongitude = point.Longitude;


                var userid = User.Identity.GetUserId();
                ApplicationUser currentuser = db.Users.FirstOrDefault(c => c.Id == userid);

                addHomeTypeRental.UserName = currentuser.UserName;
                addHomeTypeRental.UserEmail = currentuser.Email;
                addHomeTypeRental.PhoneNumber = currentuser.PhoneNumber;
                addHomeTypeRental.UserId = User.Identity.GetUserId();
                int cot = db.AddHomeTypeRental.OrderByDescending(o => o.Id).FirstOrDefault().HRCount;
                addHomeTypeRental.HRCount = cot + 1;
                db.AddHomeTypeRental.Add(addHomeTypeRental);
                await db.SaveChangesAsync();
                return RedirectToAction("Upload_Image", new { Id=addHomeTypeRental.Id});
            }

            return View(addHomeTypeRental);
        }

        // GET: AddHomeTypeRentals/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AddHomeTypeRental addHomeTypeRental = await db.AddHomeTypeRental.FindAsync(id);
            if (addHomeTypeRental == null)
            {
                return HttpNotFound();
            }
            return View(addHomeTypeRental);
        }

        // POST: AddHomeTypeRentals/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,RentalHomeType,City,Location,PropertyTitle,PropertyDescription,PropertyPrice,PropertyLandArea,PropertyLandAreaUnit,Bedrooms,Bathrooms,BuiltinYear,ParkingSpaces,DiningRoom,DrawingRoom,Kitchens,ExpiresAfter")] AddHomeTypeRental addHomeTypeRental)
        {
            if (ModelState.IsValid)
            {
                db.Entry(addHomeTypeRental).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(addHomeTypeRental);
        }

        // GET: AddHomeTypeRentals/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AllViewModel allViewModel = new AllViewModel();
            allViewModel.AddHomeTypeRental = db.AddHomeTypeRental.Find(id);
            allViewModel.RentalHomeImages = db.RentalHomeImages.Where(i => i.RentalHomeId == id).ToList();
            if (allViewModel == null)
            {
                return HttpNotFound();
            }

            return View(allViewModel);
        }

        // POST: AddHomeTypeRentals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AddHomeTypeRental addHomeTypeRental = db.AddHomeTypeRental.Find(id);
            db.RentalHomeImages.Where(p => p.RentalHomeId == addHomeTypeRental.Id).ToList().ForEach(c =>
            {
                db.RentalHomeImages.Remove(c);
            });
            db.AddHomeTypeRental.Remove(addHomeTypeRental);
            db.SaveChanges();
            return RedirectToAction("Index");
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
            return View(new RentalHomeImagesViewModel() { RentalHomeId = Id });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Upload_Image(RentalHomeImagesViewModel model)
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


                    var image = new RentalHomeImages
                    {
                        Title = model.Caption,
                        AltText = model.Caption,
                        Caption = model.Caption,
                        RentalHomeId = model.RentalHomeId,
                        CreatedDate = DateTime.Now,
                        ImageNumber = imageNumber
                    };
                    if (item != null && item.ContentLength > 0)
                    {
                        var uploadDir = "~/Uploads/";
                        var imagePath = Path.Combine(Server.MapPath(uploadDir), item.FileName);
                        var imageUrl = Path.Combine(uploadDir, item.FileName);
                        item.SaveAs(imagePath);
                        image.ImageUrl = imageUrl;

                    }

                    db.RentalHomeImages.Add(image);
                }

                db.SaveChanges();
            }

            return RedirectToAction("Index", "Home");
        }
    }
}
