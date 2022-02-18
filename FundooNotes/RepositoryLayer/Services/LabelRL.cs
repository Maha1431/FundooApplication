using CommonLayer.Label;
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
    public class LabelRL : ILabelRL
    {
        FundooNotesDbContext dbContext;
      
        public LabelRL(FundooNotesDbContext dbContext)
        {
            this.dbContext = dbContext;

        }
        public async Task<List<Label>> CreateLabel(int noteId, int Userid, LabelModel labelModel)
        {
            try
            {

                var user = dbContext.users.FirstOrDefault(e => e.Userid == Userid);
                var note = dbContext.notes.FirstOrDefault(u => u.noteId == noteId);


                Label label = new Label();
                label.Userid = Userid;
                label.noteId = noteId;
                label.labelId = new Label().labelId;
                label.LabelName = labelModel.LabelName;
                label.User = user;
                label.Notes = note;
                dbContext.label.Add(label);
                await dbContext.SaveChangesAsync();
                return await dbContext.label.Where(u => u.Userid == Userid)
                    .Include(u => u.User)
                    .Include(u => u.Notes)
                     .ToListAsync();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<List<Label>> GetAllLabels(int Userid)
        {
            Label label = new Label();
            try
            {
                return await dbContext.label.Where(u => u.Userid == Userid)
                    .Include(u => u.Notes)
                    .Include(u => u.User)
                    .ToListAsync();


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool UpdateLabel(int labelId, LabelModel labelModel)
        {
            try
            {
                Label label = dbContext.label.Where(e => e.labelId == labelId).FirstOrDefault();
                label.LabelName = labelModel.LabelName;
                dbContext.label.Update(label);
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
        public bool DeleteLabel(int labelId)
        {
            try
            {
                Label label = dbContext.label.Where(e => e.labelId == labelId).FirstOrDefault();
                if (label != null)
                {
                    dbContext.label.Remove(label);
                    dbContext.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch(Exception e)
            {
                throw e;
            }
        }
        public async Task<List<Label>> GetLabelsBynoteId(int Userid, int noteId)
        {

            //Label label = new Label();
            try
            {
                return await dbContext.label.Where(u => u.Userid == Userid && u.noteId == noteId)
                    .Include(u => u.Notes)
                    .Include(u => u.User)
                    .ToListAsync();


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }   
            
    }
}
