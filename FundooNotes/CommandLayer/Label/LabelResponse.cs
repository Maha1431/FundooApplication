using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLayer.Label
{
   public  class LabelResponse
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string LabelName { get; set; }
        public int Userid { get; set; }
        public string email { get; set; }
        public string color { get; set; }
        public DateTime registereddate { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
    }
}
