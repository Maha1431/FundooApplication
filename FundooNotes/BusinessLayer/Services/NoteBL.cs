using BusinessLayer.Interface;
using CommonLayer.Notes;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
   public class NoteBL:INoteBL
    {
        INoteRL noteRL;

        public NoteBL(INoteRL noteRL)
        {
            this.noteRL = noteRL;
        }

        
        public async Task AddNote(int userId, NotePostModel notePost)
        {
            try
            {
               await noteRL.AddNote(userId,notePost);
            }
            catch(Exception e)
            {
                throw e;
            }
        }
    }
}
