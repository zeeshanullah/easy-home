using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using EasyHome2.Models;

namespace EasyHome2.ViewModels
{
    public class PayingGuestImagesViewModel
    {
        [DataType(DataType.Html)]
        public string Caption { get; set; }

        [DataType(DataType.Upload)]
        [Display(Name = "Image Upload")]
        public List<HttpPostedFileBase> ImageUpload { get; set; }

        public int PayingGuestId { get; set; }

        public PayingGuest PayingGuest { get; set; }
    }
}