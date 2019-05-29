using EasyHome2.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EasyHome2.ViewModels
{
    public class CommercialImagesViewModel
    {

        [DataType(DataType.Html)]
        public string Caption { get; set; }

        [DataType(DataType.Upload)]
        public List<HttpPostedFileBase> ImageUpload { get; set; }

        public int CommercialId { get; set; }

        public AdCommecialProperty AdCommecialProperty { get; set; }
    }
}