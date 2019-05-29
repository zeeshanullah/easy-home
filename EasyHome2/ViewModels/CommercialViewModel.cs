using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EasyHome2.Models;

namespace EasyHome2.ViewModels
{
    public class CommercialViewModel
    {
        public List<CommercialTypes> CommercialTypes { get; set; }

        public AdCommecialProperty AdCommecialProperty { get; set; }

        public AddCommercialTypeRental AddCommercialTypeRental { get; set; }
    }
}