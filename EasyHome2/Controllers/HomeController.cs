using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EasyHome2.ViewModels;
using EasyHome2.Models;

namespace EasyHome2.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            AllCPIViewModel avm = new AllCPIViewModel();

            avm.AdCommercialProperty = db.AdCommercialProperty.ToList();
            avm.AdHomeProperty = db.AdHomeProperty.ToList();
            avm.CommercialImages = db.CommercialImages.ToList();
            avm.HomeImages = db.HomeImages.ToList();

            return View(avm);
        }

       

        [HttpPost]
        public ActionResult Index(AllCPIViewModel avm)
        {
            //AllCPIViewModel avm = new AllCPIViewModel();
            if (Request.IsAjaxRequest() && avm.SearchModel != null)
            {
                avm.AdCommercialProperty = db.AdCommercialProperty.Where(c => c.PropertyLandArea == avm.SearchModel.Area).ToList();
                if (avm.AdCommercialProperty != null && avm.AdCommercialProperty.Count > 0)
                {
                    avm.AdCommercialProperty.ForEach(prop =>
                    {
                        prop.CommercialImages = db.CommercialImages.Where(img => img.CommercialId == prop.Id).ToList();
                    });
                }
            }
            return View("Search", avm ?? new AllCPIViewModel());
        }



        [HttpGet]

        public ActionResult Search(string PropertyStatus, string PropertyTypes, string MinPrice, string MaxPrice, string MinArea, string MaxArea, string City)
        {
            AllCPIViewModel avm = new AllCPIViewModel();

            

            var MinPriceInt = Convert.ToInt32(MinPrice);
            var MaxPriceInt = Convert.ToInt32(MinPrice);

            var MinAreaInt = Convert.ToInt32(MinArea);
            var MaxAreaInt = Convert.ToInt32(MaxArea);

            if (PropertyStatus == "For Rent")
            {
                avm.AddHomeTypeRental = db.AddHomeTypeRental.Where(c => (c.PropertyPrice >= MinPriceInt && c.PropertyPrice <= MaxPriceInt) &&
                (c.PropertyLandArea >= MinAreaInt && c.PropertyLandArea <= MaxPriceInt) &&
                (c.City == City) &&
                (c.HomeTypes.HomeTypeName == PropertyTypes)
                        ).ToList();
                avm.RentalHomeImages = db.RentalHomeImages.ToList();


                avm.AddCommercialTypeRental = db.AddCommercialTypeRental.Where(c => (c.Rent >= MinPriceInt && c.Rent <= MaxPriceInt) &&
                (c.PropertyLandArea >= MinAreaInt && c.PropertyLandArea <= MaxPriceInt) &&
                (c.City == City) &&
                (c.CommercialTypes.CommercialTypeName == PropertyTypes)
                ).ToList();
                avm.RentalCommercialImages = db.RentalCommercialImages.ToList();

            }

            if (PropertyStatus == "For Sale")
            {
                avm.AdHomeProperty = db.AdHomeProperty.Where(c => (c.PropertyPrice >= MinPriceInt && c.PropertyPrice <= MaxPriceInt) &&
                (c.PropertyLandArea >= MinAreaInt && c.PropertyLandArea <= MaxPriceInt) &&
                (c.City == City) &&
                (c.HomeTypes.HomeTypeName == PropertyTypes)
                        ).ToList();
                avm.HomeImages = db.HomeImages.ToList();


                avm.AdCommercialProperty = db.AdCommercialProperty.Where(c => (c.PropertyPrice >= MinPriceInt && c.PropertyPrice <= MaxPriceInt) &&
                (c.PropertyLandArea >= MinAreaInt && c.PropertyLandArea <= MaxPriceInt) &&
                (c.City == City) &&
                (c.CommercialTypes.CommercialTypeName == PropertyTypes)
                ).ToList();
                avm.CommercialImages = db.CommercialImages.ToList();

                avm.AdPlotProperty = db.AdPlotProperty.Where(c => (c.PropertyPrice >= MinPriceInt && c.PropertyPrice <= MaxPriceInt) &&
                (c.PropertyLandArea >= MinAreaInt && c.PropertyLandArea <= MaxPriceInt) &&
                (c.City == City) &&
                (c.PlotTypes.PlotTypeName == PropertyTypes)
                ).ToList();
            }


            return View(avm);
        }
        
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }


    }
}