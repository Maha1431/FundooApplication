using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CommonLayer.Collabrator
{
   public  class CollabratorPostModel
    {
        [Required]
        [RegularExpression(@"^[A-Z0-9a-z]{1,}([.#$^_-][A-Za-z0-9]+)?[@][A-Za-z]{2,}[.][A-Za-z]{2,3}([.][a-zA-Z]{2})?$",
        ErrorMessage = "Please check ur  Email Address")]
        public string CollabEmail { get; set; }
    }
}
