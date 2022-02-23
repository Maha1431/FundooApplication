using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLayer.Notes
{
   public class NoteResponse
    {
        public int noteId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string color { get; set; }
        public DateTime registereddate { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public int Userid { get; set; }
        public string email { get; set; }
    }
}

