using CommonLayer.Collabrator;
using RepositoryLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Interface
{
  public   interface ICollabRL
    {
        Task<List<Collabarator>> AddCollabrator(int Userid, int noteId, CollabratorPostModel postModel);
        Task<List<Collabarator>> GetAllCollabs(int Userid, int noteId);
        Task RemoveCollab(int CollabId, int Userid);
    }
}
