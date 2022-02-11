using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace CommonLayer.User
{
   public class UserPostModel
    {
        [RegularExpression(@"^[A-Za-z]{3,}$",
        ErrorMessage= "Please enter a valid First name")]
        public string firstname { get; set; }

        [RegularExpression(@"^[A-Za-z]{3,}$",
        ErrorMessage = "Please enter a valid Last name")]
        public string lastname { get; set; }

        [RegularExpression(@"^[6-9]{1}[0-9]{2,}$",
        ErrorMessage= "Please enter a valid Phone number")]
        public int phone { get; set; }

        [RegularExpression(@"^[a-zA-Z0-9]{5,}$",
        ErrorMessage = "Please enter a valid Address")]
        public string adddress { get; set; }

        [RegularExpression(@"^[A-Z0-9a-z]{1,}([.#$^_-][A-Za-z0-9]+)?[@][A-Za-z]{2,}[.][A-Za-z]{2,3}([.][a-zA-Z]{2})?$",
        ErrorMessage = "Please check ur  Email Address")]
        public string email { get; set; }

        [RegularExpression(@"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$",
        ErrorMessage = "Please enter a valid Password")]
        public string password { get; set; }

        [RegularExpression(@"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$",
        ErrorMessage = "Please enter a valid Password")]
        public string cpassword { get; set; }
       
    }
}
