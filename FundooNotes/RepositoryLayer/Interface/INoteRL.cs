using CommonLayer.Notes;
using RepositoryLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Interface
{
  public  interface INoteRL
    {
        Task AddNote(int Userid,  NotePostModel notePost);

        bool UpdateNote(int noteId, NotePostModel notePost);

        Task<List<Notes>> GetAllNotes();

        bool DeleteNote(int noteId);

        Task<List<Notes>> changeColor(int noteId, string color);

        Task ArchieveNote(int noteId);

        bool IsPin(int noteId);

        Task Trash(int noteId);

        
}
}
