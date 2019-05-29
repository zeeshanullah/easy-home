using EasyHome2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EasyHome2.ViewModels
{
    public class AvmViewModel
    {

        public List<AdCommecialProperty> AdCommercialProperty { get; set; }

        public List<AddCommercialTypeRental> AddCommercialTypeRental { get; set; }

        public List<AddHomeTypeRental> AddHomeTypeRental { get; set; }
        public List<AdHomeProperty> AdHomeProperty { get; set; }

        public List<AdPlotProperty> AdPlotProperty { get; set; }
        public List<PayingGuest> PayingGuest { get; set; }

    }
}