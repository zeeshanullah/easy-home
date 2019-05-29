using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EasyHome2.Models
{
    public class PayingGuest
    {
        public int Id { get; set; }

        public int PGCount { get; set; }
        public double AddressLatitude { get; set; }

        public double AddressLongitude { get; set; }

        public string Address { get; set; }

        public string UserName { get; set; }

        [Display(Name = "Contact No.")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Email")]
        public string UserEmail { get; set; }


        public string Title { get; set; }

        [Display(Name ="Charges Per Day")]
        public int ChargesPerHour { get; set; }

        public string Description { get; set; }

        public byte Rooms { get; set; }

        public string UserId { get; set; }

        public string City { get; set; }

        public string Location { get; set; }

        public List<PayingGuestImages> PayingGuestImages { get; set; }

    }
}