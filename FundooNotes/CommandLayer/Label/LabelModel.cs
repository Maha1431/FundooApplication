using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CommonLayer.Label
{
   public class LabelModel
    {
        [RegularExpression(@"^[A-Za-z]{3,}$",
        ErrorMessage = "Please enter a valid Label name")]
        [Required]
        public string LabelName { get; set; }
        
       
        
    }
}
