using CommonLayer.Collabrator;
using RepositoryLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interface
{
   public interface ICollabBL
    {
        Task<List<Collabarator>> AddCollabrator(int Userid, int noteId, CollabratorPostModel postModel);
        Task<List<Collabarator>> GetAllCollabsbynoteId(int Userid, int noteId);
        Task RemoveCollab(int CollabId, int Userid);
    }
}
