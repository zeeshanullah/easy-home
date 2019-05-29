using EasyHome2.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EasyHome2.ViewModels
{
    public class RentalHomeImagesViewModel
    {

        [DataType(DataType.Html)]
        public string Caption { get; set; }

        [DataType(DataType.Upload)]
        public List<HttpPostedFileBase> ImageUpload { get; set; }


        public int RentalHomeId { get; set; }
        public AddHomeTypeRental RentalHome { get; set; }
    }
}