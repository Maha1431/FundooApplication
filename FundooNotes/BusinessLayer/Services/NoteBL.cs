using BusinessLayer.Interface;
using CommonLayer.Notes;
using RepositoryLayer.Entities;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public class NoteBL : INoteBL
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
                await noteRL.AddNote(userId, notePost);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public bool UpdateNote(int noteId, NotePostModel notePost)
        {
            try
            {
                if (noteRL.UpdateNote(noteId, notePost))
                    return true;
                else
                    return false;
            }
            catch (Exception e)
            {

                throw e;
            }
        }
        public async Task<List<Notes>> GetAllNotes()
        {

            try
            {
                return await noteRL.GetAllNotes();
            }
            catch (Exception e)
            {

                throw e;
            }

        }

        public bool DeleteNote(int noteId)
        {
            try
            {
                if (noteRL.DeleteNote(noteId))
                    return true;
                else
                    return false;
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public async Task<List<Notes>> changeColor(int noteId, string color)
        {
            try
            {
                return await noteRL.changeColor(noteId, color);
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
                await noteRL.ArchieveNote(noteId);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public bool IsPin(int noteId)
        {
            try
            {
                var result = this.noteRL.IsPin(noteId);
                if(noteId != 0)
                {
                    return result;
                }
                else
                {
                    throw new Exception("Note cant be pinned");
                }
            }
            catch(Exception e)
            {
                throw e;
            }
        }
    }
}
