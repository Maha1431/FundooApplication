﻿using CommonLayer.Notes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interface
{
    public interface INoteBL
    {
        Task AddNote(int userId, NotePostModel notePost);

        bool UpdateNote(int noteId, NotePostModel notePost);

        IEnumerable<Notes> GetAllNotes();

        bool DeleteNote(int noteId);

        Task<List<Notes>> changeColor(int noteId, string color);

        Task ArchieveNote(int noteId);

        bool IsPin(int noteId);
    }
}
