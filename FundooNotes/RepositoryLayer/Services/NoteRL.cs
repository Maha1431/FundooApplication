using CommonLayer.Notes;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RepositoryLayer.Entities;
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
        public async Task AddNote(int Userid, NotePostModel notePost)
        {
            try
            {
              // var user = dbContext.users.FirstOrDefault(x => x.Userid == userId);
                Notes note = new Notes();
                note.noteId = new Notes().noteId;
                note.Userid = Userid;
                note.Title = notePost.Title;
                note.Description = notePost.Description;
                note.IsReminder = notePost.IsReminder;
                note.CreatedDate = DateTime.Now;
                note.ModifiedDate = DateTime.Now;
                note.color = notePost.color;
                note.IsArchive = note.IsArchive;
                dbContext.notes.Add(note);
                await dbContext.SaveChangesAsync();     
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public  bool UpdateNote(int noteId, NotePostModel notePost)
        {
            try
            {
                Notes notes = dbContext.notes.Where(e => e.noteId == noteId).FirstOrDefault();
                notes.Title = notePost.Title;
                notes.Description = notePost.Description;
                notes.color = notePost.color;
                notes.IsReminder = notePost.IsReminder;
                notes.IsArchive = notePost.IsArchive;
                notes.IsTrash = notePost.IsTrash;
                notes.IsPin = notePost.IsPin;
                dbContext.notes.Update(notes);
                var result = dbContext.SaveChangesAsync();
                if (result != null)
                {
                  return true;
                }
                else
                    return false;
            }
            catch(Exception e)
            {
                throw e;
            }
        }
        public async Task<List<Notes>> GetAllNotes(int Userid)
        {
            // return await dbContext.notes.ToListAsync();
            return await dbContext.notes.Where(u => u.Userid == Userid)

                 .Include(u => u.user)
                 .ToListAsync();
        }

        public bool DeleteNote(int noteId)
        {
            Notes notes = dbContext.notes.Where(e => e.noteId == noteId).FirstOrDefault();
            if (notes != null)
            {
                dbContext.notes.Remove(notes);
                dbContext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
        public async Task<List<Notes>> changeColor(int noteId, string color)
        {
            try
            {
                var note = dbContext.notes.FirstOrDefault(u => u.noteId == noteId);
                note.color = color;
                await dbContext.SaveChangesAsync();
                return await dbContext.notes.ToListAsync();

            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task ArchieveNote(int noteId)
        {
            try
            {
                var note = dbContext.notes.FirstOrDefault(u => u.noteId == noteId);
                note.IsArchive = true;
                await dbContext.SaveChangesAsync();

            }
            catch (Exception e)
            {

            }
        }
        public bool IsPin(int noteId)
        {
            try
            {
                Notes notes = dbContext.notes.Where(e => e.noteId == noteId).FirstOrDefault();
                if (notes != null)
                {
                    return true;
                }
                else
                {

                    return false;
                }

            }
            catch (Exception e)
            {
                throw e;
            }

        }

        public async Task TrashNote(int noteId)
        {
            try
            {
                Notes note = dbContext.notes.FirstOrDefault(e => e.noteId == noteId);
                if (note != null)
                {
                    note.IsTrash = true;
                    await dbContext.SaveChangesAsync();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

    }
}
