using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CommonLayer.Collabrator
{
   public  class CollabratorPostModel
    {
        [Required]
        public string CollabEmail { get; set; }
    }
}
