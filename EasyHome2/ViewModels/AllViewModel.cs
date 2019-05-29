using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EasyHome2.Models;
using EasyHome2.ViewModel;
namespace EasyHome2.ViewModels
{

    public class AllViewModel
    {
        public AdCommecialProperty AdCommercialProperty { get; set; }

        public IEnumerable<CommercialImages> CommercialImages { get; set; }
        
        /// /////////////////////////////////////
        
        public PayingGuest PayingGuest { get; set; }

        public List<PayingGuestImages> PayingGuestImages { get; set; }

        public AddCommercialTypeRental AddCommercialTypeRental { get; set; }

        public List<RentalCommercialImages> RentalCommercialImages { get; set; }

        /// /////////////////////////////////////

        public AddHomeTypeRental AddHomeTypeRental { get; set; }
        public List<RentalHomeImages> RentalHomeImages { get; set; }

        /// //////////////////////////////////////////

        public List<HomeImages> HomeImages { get; set; }
        public AdHomeProperty AdHomeProperty { get; set; }

        /// ///////////////////////////////////

        public List<AdPlotProperty> AdPlotProperty { get; set; }

        public AdPlotProperty adplotprop { get; set; }
    }
}