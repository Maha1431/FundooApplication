using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLayer.Label
{
    public class LabelResponse
    {
        public int Userid { get; set; }
        public string LabelName { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string color { get; set; }
        public int noteId { get; set; }
        public string email { get; set; }
        //public virtual Notes notes { get; set; }
    }
}
