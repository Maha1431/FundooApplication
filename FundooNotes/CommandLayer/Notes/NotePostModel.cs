using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CommonLayer.Notes
{
   public class NotePostModel
    {
        /*[Required]
        public int noteId { get; set; }
        [Required]
        public int userId { get; set; }*/
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public bool IsReminder { get; set; }
        [Required]
        public DateTime ModifiedDate { get; set; }
        [Required]
        public string color { get; set; }
        [Required]
        public bool IsArchive { get; set; }
        [Required]
        public bool IsTrash { get; set; }
        [Required]
        public bool IsPin { get; set; }
    }
}
