using CommonLayer.Collabrator;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.Entities;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Services
{
    public class CollabRL : ICollabRL
    {
        FundooNotesDbContext dbContext;

        public CollabRL(FundooNotesDbContext dbContext)
        {
            this.dbContext = dbContext;

        }

        public async Task<List<Collabarator>> AddCollabrator(int Userid, int noteId, CollabratorPostModel postModel)
        {
            try
            {
                var user = dbContext.users.FirstOrDefault(e => e.Userid == Userid);
                var note = dbContext.notes.FirstOrDefault(u => u.noteId == noteId);


                Collabarator collabarator = new Collabarator();
                collabarator.Userid = Userid;
                collabarator.noteId = noteId;
                collabarator.CollabId = new Collabarator().CollabId;
                collabarator.CollabEmail = postModel.CollabEmail;
                collabarator.User = user;
                collabarator.Notes = note;
                dbContext.collabarators.Add(collabarator);
                await dbContext.SaveChangesAsync();
                return await dbContext.collabarators.Where(u => u.Userid == Userid)
                    .Include(u => u.User)
                    .Include(u => u.Notes)
                     .ToListAsync();

            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<List<Collabarator>> GetAllCollabsbynoteId(int Userid, int noteId)
        {
            try
            {
               Collabarator collabarator = new Collabarator();
               
                return await dbContext.collabarators.Where(u => u.Userid == Userid && u.noteId == noteId)
                    .Include(u => u.Notes)
                    .Include(u => u.User)
                    
                    .ToListAsync();



            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task RemoveCollab(int CollabId, int Userid)
        {
           try
            {
                Collabarator collabarator = await dbContext.collabarators.Where(u => u.CollabId == CollabId).FirstOrDefaultAsync();
                if (collabarator != null)
                {
                   // Collabarator collabarator = new Collabarator();
                    this.dbContext.collabarators.Remove(collabarator);
                    await this.dbContext.SaveChangesAsync();
                    // await dbContext.collabarators.ToListAsync();
                }
               
            }
            catch(Exception e)
            {
                throw e;
            }
        }
    }
}


