using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VegeFoods.Models.AdminModel
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Acount cannot be empty")]
        public string Account { get; set; }
        [Required(ErrorMessage = "Password cannot be empty")]
        public string Password { get; set; }
    }
}