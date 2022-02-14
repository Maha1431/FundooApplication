using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CommonLayer.Notes
{
  public  class Notes
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int noteId { get; set; }
        public int userId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsReminder { get; set; }
        public string color { get; set; }
        public bool IsArchive { get; set; }
        public bool IsTrash { get; set; }
        public bool IsPin { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
      

        
      //  public  User.User user { get; set; }

    }
}
