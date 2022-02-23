using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLayer.Label
{
    public class LabelResponse
    {
       public int labelId { get; set; }
        public string LabelName { get; set; }
        public string color { get; set; }
        public int noteId { get; set; }
        //public virtual Notes notes { get; set; }
    }
}
