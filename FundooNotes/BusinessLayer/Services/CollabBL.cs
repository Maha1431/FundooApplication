using BusinessLayer.Interface;
using CommonLayer.Collabrator;
using RepositoryLayer.Entities;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
   public class CollabBL:ICollabBL
    {
        ICollabRL collabratorRL;
        public CollabBL(ICollabRL collabratorRL)
        {
            this.collabratorRL = collabratorRL;
        }

        public async Task<List<Collabarator>> AddCollabrator(int Userid, int noteId, CollabratorPostModel postModel)
        {
            try
            {
                return await collabratorRL.AddCollabrator( Userid, noteId, postModel);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<Collabarator>> GetAllCollabs(int Userid, int noteId)
        {
            try
            {
                return await collabratorRL.GetAllCollabs(Userid,noteId);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task RemoveCollab(int CollabId, int Userid)
        {
            try
            {
                 await collabratorRL.RemoveCollab(CollabId, Userid);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
