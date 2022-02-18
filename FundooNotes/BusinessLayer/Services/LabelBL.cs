using BusinessLayer.Interface;
using CommonLayer.Label;
using RepositoryLayer.Entities;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
   public class LabelBL:ILabelBL
    {
        ILabelRL labelRL;

        public LabelBL(ILabelRL labelRL)
        {
            this.labelRL = labelRL;
        }
        public async Task<List<Label>> CreateLabel(int noteId, int Userid, LabelModel labelModel)
        {
            try
            {
              return  await labelRL.CreateLabel(noteId, Userid, labelModel);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<List<Label>> GetAllLabels(int Userid)
        {
            try
            {
                return await labelRL.GetAllLabels(Userid);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool UpdateLabel(int labelId, LabelModel labelModel)
        {
            try
            {
                if (labelRL.UpdateLabel(labelId, labelModel))
                    return true;
                else
                    return false;
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public bool DeleteLabel(int labelId)
        {
            try
            {
                if (labelRL.DeleteLabel(labelId))
                    return true;
                else
                    return false;
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public async Task<List<Label>> GetLabelsBynoteId(int Userid, int noteId)
        {
            try
            {
                return await labelRL.GetLabelsBynoteId(Userid,noteId);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
