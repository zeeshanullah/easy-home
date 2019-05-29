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
using EasyHome2.ViewModels;
using System.IO;
using Microsoft.AspNet.Identity;
using GoogleMaps.LocationServices;

namespace EasyHome2.Controllers
{
    public class AddCommercialTypeRentalsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: AddCommercialTypeRentals
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
            avm.AddCommercialTypeRental = db.AddCommercialTypeRental.ToList();
            avm.RentalCommercialImages = db.RentalCommercialImages.ToList();
            ////return View(db.AdCommercialProperty.ToList());
            return View(avm);
        }

        // GET: AddCommercialTypeRentals/Details/5
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
            allViewModel.AddCommercialTypeRental = db.AddCommercialTypeRental.Find(id);
            allViewModel.RentalCommercialImages = db.RentalCommercialImages.Where(i => i.RentalCommercialId == id).ToList();
            return View(allViewModel);
        }

        // GET: AddCommercialTypeRentals/Create
        public ActionResult Create()
        {
            if (User.Identity.GetUserId() == null)
            {
                return RedirectToAction("Register", "Account");
            }
            var Commercialtypes = db.CommercialTypes.ToList();
            var viewmodel = new CommercialViewModel
            {
                AddCommercialTypeRental = new AddCommercialTypeRental(),
                CommercialTypes = Commercialtypes
            };
            return View(viewmodel);
        }

        // POST: AddCommercialTypeRentals/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,CommercialTypeId,City,Location,PropertyTitle,PropertyDescription,Rent,PropertyLandArea,PropertyLandAreaUnit,BuiltinYear,Bathrooms,ExpiresAfter,Address")] AddCommercialTypeRental addCommercialTypeRental)
        {
            if (ModelState.IsValid)
            {
                var locationService = new GoogleLocationService();
                var point = locationService.GetLatLongFromAddress(addCommercialTypeRental.Address);
                addCommercialTypeRental.AddressLatitude = point.Latitude;
                addCommercialTypeRental.AddressLongitude = point.Longitude;

                var userid = User.Identity.GetUserId();
                ApplicationUser currentuser = db.Users.FirstOrDefault(c => c.Id == userid);
                
                addCommercialTypeRental.UserName = currentuser.UserName;
                addCommercialTypeRental.UserEmail = currentuser.Email;
                addCommercialTypeRental.PhoneNumber = currentuser.PhoneNumber;
                addCommercialTypeRental.UserId = User.Identity.GetUserId();
                int cot = db.AddCommercialTypeRental.OrderByDescending(o => o.Id).FirstOrDefault().CRCount;
                addCommercialTypeRental.CRCount = cot + 1;
                db.AddCommercialTypeRental.Add(addCommercialTypeRental);
                await db.SaveChangesAsync();
                return RedirectToAction("Upload_Image",new { Id=addCommercialTypeRental.Id});
            }

            return View(addCommercialTypeRental);
        }

        // GET: AddCommercialTypeRentals/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AddCommercialTypeRental addCommercialTypeRental = await db.AddCommercialTypeRental.FindAsync(id);
            if (addCommercialTypeRental == null)
            {
                return HttpNotFound();
            }
            return View(addCommercialTypeRental);
        }

        // POST: AddCommercialTypeRentals/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,CommercialTypeId,City,Location,PropertyTitle,PropertyDescription,Rent,PropertyLandArea,PropertyLandAreaUnit,BuiltinYear,Bathrooms,ExpiresAfter")] AddCommercialTypeRental addCommercialTypeRental)
        {
            if (ModelState.IsValid)
            {
                db.Entry(addCommercialTypeRental).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(addCommercialTypeRental);
        }

        // GET: AddCommercialTypeRentals/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AllViewModel allViewModel = new AllViewModel();
            allViewModel.AddCommercialTypeRental = db.AddCommercialTypeRental.Find(id);
            allViewModel.RentalCommercialImages = db.RentalCommercialImages.Where(i => i.RentalCommercialId == id).ToList();
            if (allViewModel == null)
            {
                return HttpNotFound();
            }

            return View(allViewModel);
        }

        // POST: AddCommercialTypeRentals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AddCommercialTypeRental addCommercialTypeRental = db.AddCommercialTypeRental.Find(id);
            db.RentalCommercialImages.Where(p => p.RentalCommercialId ==addCommercialTypeRental.Id).ToList().ForEach(c =>
            {
                db.RentalCommercialImages.Remove(c);
            });
            db.AddCommercialTypeRental.Remove(addCommercialTypeRental);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        /*  protected override void Dispose(bool disposing)
          {
              if (disposing)
              {
                  db.Dispose();
              }
              base.Dispose(disposing);
          }*/

        public ActionResult Upload_Image(int Id)
        {
            return View(new RentalCommercialImagesViewModel() { RentalCommercialId = Id });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Upload_Image(RentalCommercialImagesViewModel model)
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

                    var image = new RentalCommercialImages
                    {
                        Title = model.Caption,
                        AltText = model.Caption,
                        Caption = model.Caption,
                        RentalCommercialId = model.RentalCommercialId,
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

                    db.RentalCommercialImages.Add(image);
                }

                db.SaveChanges();
            }

            return RedirectToAction("Index", "Home");
        }
    }
}
