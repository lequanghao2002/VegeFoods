using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VegeFoods.Models.AdminModel
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "Account cannot be empty")]
        public string Account { get; set; }

        [Required(ErrorMessage = "Password cannot be empty")]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "Password length at least 6 characters")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm password cannot be empty")]
        [Compare("Password", ErrorMessage = "Confirm password does not match password")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Full name cannot be empty")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Email cannot be empty")]
        public string Email { get; set; }

        //[Required(ErrorMessage = "Phone number cannot be empty")]
        public string PhoneNumber { get; set; }
        
    }
}