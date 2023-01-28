using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VegeFoods.Models.CustomerModel
{
    public class CheckOutModel
    {
        public int User_ID { get; set; }
        public string FullName { get; set; }

        public string Address { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }
    }
}