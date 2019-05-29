using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EasyHome2.Models;
namespace EasyHome2.ViewModels
{
    public class HomeViewModel
    {
        public List<HomeTypes> HomeTypes { get; set; }
        public AdHomeProperty AdHomeProperty { get; set; }

        public AddHomeTypeRental AddHomeTypeRental { get; set; }
    }
}