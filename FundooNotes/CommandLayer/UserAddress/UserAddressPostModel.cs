using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CommonLayer.UserAddress
{
  public  class UserAddressPostModel
    {
        [Required]
        public string Type { get; set; }

        [Required]
        [RegularExpression("(?=.*[a-zA-Z]).{4,50}$", ErrorMessage = "address has minimum 4 characters")]
        public string Address { get; set; }
        [Required]
        [RegularExpression("^[A-Z]{1}[a-z]{4,50}$", ErrorMessage = "city starts with Cap and has minimum 4 characters")]
        public string City { get; set; }
        [Required]
        [RegularExpression("^[A-Z]{1}[a-z]{4,50}$", ErrorMessage = "state starts with Cap and has minimum 4 characters")]
        public string State { get; set; }

    }
}
