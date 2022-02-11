using CommonLayer.Notes;
using Microsoft.Extensions.Configuration;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Services
{
    public class NoteRL : INoteRL
    {
        FundooNotesDbContext dbContext;
        private readonly IConfiguration configuration;

        public NoteRL(FundooNotesDbContext dbContext)
        {
            this.dbContext = dbContext;

        }
        public async Task AddNote(int userId, NotePostModel notePost)
        {
            try
            {
               var user = dbContext.users.FirstOrDefault(x => x.Userid == userId);
                Notes note = new Notes();
                note.noteId = new Notes().noteId;
                note.Title = notePost.Title;
                note.Description = notePost.Description;
                note.IsReminder = notePost.IsReminder;
                note.CreatedDate = DateTime.Now;
                note.ModifiedDate = notePost.ModifiedDate;
                note.color = notePost.color;
                note.IsArchive = note.IsArchive;
                dbContext.notes.Add(note);
               // dbContext.SaveChanges();
                await dbContext.SaveChangesAsync();     
            }
            catch(Exception e)
            {
                throw e;
            }
        }

    }
}
