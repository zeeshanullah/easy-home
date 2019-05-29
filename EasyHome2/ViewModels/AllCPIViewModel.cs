using EasyHome2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EasyHome2.ViewModels
{
    public class AllCPIViewModel
    {
        public List<AdCommecialProperty> AdCommercialProperty { get; set; }

        public List<CommercialImages> CommercialImages { get; set; }
       
        /// /////////////////////////////
       
        public List<AddCommercialTypeRental> AddCommercialTypeRental { get; set; }

        public List<RentalCommercialImages> RentalCommercialImages { get; set; } 
        
        /// /////////////////////////////////////
        
        public List<AddHomeTypeRental> AddHomeTypeRental { get; set; }
        public List<RentalHomeImages> RentalHomeImages { get; set; }
        
        /// //////////////////////////////////////////
        
        public List<HomeImages> HomeImages { get; set; }
        public List<AdHomeProperty> AdHomeProperty { get; set; }
        
        /// ///////////////////////////////////
       
        public List<AdPlotProperty> AdPlotProperty { get; set; }
        
        /// /////////////////////////////
        
        public List<PayingGuest> PayingGuest { get; set; }
        public List<PayingGuestImages> PayingGuestImages { get; set; }




        public SearchModel SearchModel { get; set; }

        public List<Object> PropertyStatusSelectList()
        {
            return new List<object> {
                new  { id = 1, PropertyStatus="For Sale" },
                new  { id = 1, PropertyStatus="For Rent" }
            };
        }

        public List<Object> PropertyTypesSelectList()
        {
            return new List<object> {
                new  { id = 1, PropertyTypes="Residential" },
                new  { id = 1, PropertyTypes="Commercial" },
                new  { id = 1, PropertyTypes="Plot" }
            };
        }

        public List<Object> AreaSelectList()
        {
            return new List<object> {
                new  { id = 1, Area="1" },
                new  { id = 2, Area="2" },
                new  { id = 3, Area="3" },
                new  { id = 4, Area="4" },
                new  { id = 5, Area="5" },
                new  { id = 6, Area="6" },
                new  { id = 7, Area="7" },
                new  { id = 8, Area="8" },
                new  { id = 9, Area="9" },
                new  { id = 10, Area="10" },
                new  { id = 11, Area="11" },
                new  { id = 12, Area="12" },
                new  { id = 13, Area="13" },
                new  { id = 14, Area="14" },
                new  { id = 15, Area="15" },
                new  { id = 16, Area="16" },
                new  { id = 17, Area="17" },
                new  { id = 18, Area="18" },
                new  { id = 19, Area="19" },
                new  { id = 20, Area="20" }
            };
        }
        public List<Object> AreaUnitSelectList()
        {
            return new List<object> {
                new  { id = 1, AreaUnit="Marla" },
                new  { id = 1, AreaUnit="Kanal" },
                new  { id = 1, AreaUnit="Acre" }
            };
        }
        public List<Object> MinPriceSelectList()
        {
            return new List<object> {
                new  { id = 1, MinPrice="1 Lac" },
                new  { id = 1, MinPrice="25 Lac" },
                new  { id = 1, MinPrice="50 Lac" },
                new  { id = 1, MinPrice="1 Crore" },
                new  { id = 1, MinPrice="2 Crore" },
                new  { id = 1, MinPrice="5 Crore" },

            };
        }

        public List<Object> MaxPriceSelectList()
        {
            return new List<object> {
                new  { id = 1, MaxPrice="25 Lac" },
                new  { id = 1, MaxPrice="50 Lac" },
                new  { id = 1, MaxPrice="1 Crore" },
                new  { id = 1, MaxPrice="2 Crore" },
                new  { id = 1, MaxPrice="5 Crore" },
                new  { id = 1, MaxPrice="50 Crore" }

            };
        }

        public List<Object> CitySelectList()
        {
            return new List<object> {
                new  { id = 1, City="Lahore" },
                new  { id = 1, City="Islamabad" },
                new  { id = 1, City="Karachi" },
                new  { id = 1, City="Multan" },
                new  { id = 1, City="Rawalpindi" },
                new  { id = 1, City="Faisalabad" }

            };
        }

    }

    public class SearchModel
    {
        // public int Area { get; set; }
        public int Area { get; set; }
        public string AreaUnit { get; set; }
        public string PropertyStatus { get; set; }
        public string PropertyTypes { get; set; }
        public string MinPrice { get; set; }
        public string MaxPrice { get; set; }
        public string City { get; set; }
    }
}