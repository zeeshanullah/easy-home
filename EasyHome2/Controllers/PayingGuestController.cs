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

namespace EasyHome2.Controllers
{
    public class PayingGuestController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: PayingGuest
        public ActionResult Index()
        {
            AllCPIViewModel allViewModel = new AllCPIViewModel();
            allViewModel.PayingGuest = db.PayingGuest.ToList();
            allViewModel.PayingGuestImages = db.PayingGuestImages.ToList();
            return View(allViewModel);
        }

        // GET: PayingGuest/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            /* PayingGuest payingGuest = await db.PayingGeust.FindAsync(id);
             if (payingGuest == null)
             {
                 return HttpNotFound();
             }*/

            AllViewModel allViewModel = new AllViewModel();
            allViewModel.PayingGuest = db.PayingGuest.Find(id);
            allViewModel.PayingGuestImages = db.PayingGuestImages.Where(i => i.PayingGuestId == id).ToList();
            return View(allViewModel);
        }

        // GET: PayingGuest/Create
        public ActionResult Create()
        {
            if (User.Identity.GetUserId() == null)
            {
                return RedirectToAction("Register", "Account");
            }
            return View();
        }

        // POST: PayingGuest/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Title,ChargesPerHour,Description,Rooms,Address")] PayingGuest payingGuest)
        {
            if (ModelState.IsValid)
            {

                var userid = User.Identity.GetUserId();
                ApplicationUser currentuser = db.Users.FirstOrDefault(c => c.Id == userid);

                payingGuest.UserName = currentuser.UserName;
                payingGuest.UserEmail = currentuser.Email;
                payingGuest.PhoneNumber = currentuser.PhoneNumber;
                payingGuest.UserId = userid;
                int cot = db.PayingGuest.OrderByDescending(o => o.Id).FirstOrDefault().PGCount;
                payingGuest.PGCount = cot + 1;
                db.PayingGuest.Add(payingGuest);
                await db.SaveChangesAsync();
                return RedirectToAction("Upload_Image", new { Id=payingGuest.Id});
            }

            return View(payingGuest);
        }

        // GET: PayingGuest/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PayingGuest payingGuest = await db.PayingGuest.FindAsync(id);
            if (payingGuest == null)
            {
                return HttpNotFound();
            }
            return View(payingGuest);
        }

        // POST: PayingGuest/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Title,ChargesPerHour,Description,Rooms")] PayingGuest payingGuest)
        {
            if (ModelState.IsValid)
            {
                db.Entry(payingGuest).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(payingGuest);
        }

        // GET: PayingGuest/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PayingGuest payingGuest = await db.PayingGuest.FindAsync(id);
            if (payingGuest == null)
            {
                return HttpNotFound();
            }
            return View(payingGuest);
        }

        // POST: PayingGuest/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            PayingGuest payingGuest = await db.PayingGuest.FindAsync(id);
            db.PayingGuest.Remove(payingGuest);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }


        public ActionResult BookNow()
        {
            return View();
        }

        public ActionResult Upload_Image(int Id)
        {
            return View(new PayingGuestImagesViewModel() { PayingGuestId = Id });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Upload_Image(PayingGuestImagesViewModel model)
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


                    var image = new PayingGuestImages
                    {
                        Title = model.Caption,
                        AltText = model.Caption,
                        Caption = model.Caption,
                        PayingGuestId = model.PayingGuestId,
                        CreatedDate = DateTime.Now,
                        ImageNumber=imageNumber
                    };
                    if (item != null && item.ContentLength > 0)
                    {
                        var uploadDir = "~/CommercialUploads/";
                        var imagePath = Path.Combine(Server.MapPath(uploadDir), item.FileName);
                        var imageUrl = Path.Combine(uploadDir, item.FileName);
                        item.SaveAs(imagePath);
                        image.ImageUrl = imageUrl;

                    }

                    db.PayingGuestImages.Add(image);
                }

                db.SaveChanges();
            }

            return RedirectToAction("Index", "Home");

        }


        /* protected override void Dispose(bool disposing)
         {
             if (disposing)
             {
                 db.Dispose();
             }
             base.Dispose(disposing);
         }*/
    }


}
