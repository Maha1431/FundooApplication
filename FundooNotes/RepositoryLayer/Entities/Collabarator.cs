using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RepositoryLayer.Entities
{
   public class Collabarator
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int CollabId { get; set; }
        public string CollabEmail { get; set; }

        [ForeignKey("Notes")]
        public int? noteId { get; set; }
        public virtual Notes Notes { get; set; }

        [ForeignKey("User")]
        public int? Userid { get; set; }
        public virtual User User { get; set; }
    }
}
