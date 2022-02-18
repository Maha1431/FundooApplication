using BusinessLayer.Interface;
using CommonLayer.Notes;
using Microsoft.AspNetCore.Mvc;
using RepositoryLayer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using BusinessLayer.Services;
using RepositoryLayer.Entities;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Caching.Distributed;
using System.Text;
using Newtonsoft.Json;

namespace FundooNotes.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class NoteController : ControllerBase
    {
        private readonly IMemoryCache memoryCache;
        private readonly IDistributedCache distributedCache;
        INoteBL noteBL;
        FundooNotesDbContext DbContext;
        public NoteController(INoteBL noteBL, FundooNotesDbContext DbContext, IMemoryCache memoryCache, IDistributedCache distributedCache)
        {
            this.noteBL = noteBL;
            this.DbContext = DbContext;
            this.memoryCache = memoryCache;
            this.distributedCache = distributedCache;

        }
        [Authorize]
        [HttpPost("addNotes")]
        public async Task<IActionResult> AddNotes(NotePostModel notePost)
        {
            try
            {
                int userId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "Userid").Value);
                await this.noteBL.AddNote(userId,notePost);

                return this.Ok(new { success = true, Message = $"Registration is successfull" });
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [HttpPut("updatenote/{noteId}")]
        public IActionResult UpdateNotes(int noteId, NotePostModel notePost)
        {
            try
            {
                if (noteBL.UpdateNote(noteId, notePost))
                {
                    return this.Ok(new { Success = true, message = "Notes updated successfully", response = noteId, notePost });
                }
                else
                {
                    return this.BadRequest(new { Success = false, message = "Note with given ID not found" });
                }
            }
            catch (Exception e)
            {

                throw e;
            }
        }
         [Authorize]
        [HttpGet("getAllNotesusingRedis")]
        public async Task<IActionResult> GetAllNotes()
        {
            try
            {
                var cacheKey = "noteList";
                string serializedNoteList;
                var noteList = new List<Notes>();
                var redisnoteList = await distributedCache.GetAsync(cacheKey);
                if (redisnoteList != null)
                {
                    serializedNoteList = Encoding.UTF8.GetString(redisnoteList);
                    noteList = JsonConvert.DeserializeObject<List<Notes>>(serializedNoteList);
                }
                else
                {
                    
                   // noteList = await noteBL.GetAllNotes(Userid);
                    serializedNoteList = JsonConvert.SerializeObject(noteList);
                    redisnoteList = Encoding.UTF8.GetBytes(serializedNoteList);
                }
                return this.Ok(noteList);

            }
            catch (Exception)
            {

                throw;
            }
        }
        //[Authorize]
        [HttpDelete("delete/{noteId}")]
        public IActionResult DeleteNote(int noteId)
        {
            try
            {
                if (noteBL.DeleteNote(noteId))
                {
                    return this.Ok(new { Success = true, message = "Notes deleted successfully" });

                }
                else
                {
                    return this.BadRequest(new { Success = false, message = "Notes with given ID not found" });
                }

            }
            catch (Exception)
            {

                throw;
            }
        }
        //[Authorize]
        [HttpPut("changeColor/{noteId}/{color}")]
        public async Task<IActionResult> changeColor(int noteId, string color)
        {
            try
            {
                List<Notes> note = await noteBL.changeColor(noteId, color);
                if (note != null)
                {
                    return this.Ok(new { Success = true, message = "Color changed successfully", data = note });
                }
                else
                {
                    return this.BadRequest(new { Success = false, message = "Notes with given ID not found" });
                }

            }
            catch (Exception e)
            {

                throw e;
            }
        }

        [HttpPut("archiveNote/{noteId}")]
        public async Task<IActionResult> IsArchieve(int noteId)
        {
            try
            {

                await noteBL.ArchieveNote(noteId);
                return this.Ok(new { Success = true, message = $"NoteArchieve successfull for {noteId}" });

            }
            catch (Exception e)
            {
                throw e;
            }


        }
        [HttpPut("pin/{noteId}")]
        public IActionResult Pin(int noteId)
        {
            try
            {
                var status = noteBL.IsPin(noteId);
                if (status == true)
                {
                    return Ok(new { success = true, Message = "Note successfully pinned", Notes = status });
                }
                else
                {
                    return BadRequest(new { success = false, Message = "Unable to pin note" });
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        [HttpDelete("trash/{noteId}")]
        public ActionResult<Notes> Trash(int noteId)
        {
            try
            {
                this.noteBL.TrashNote(noteId);
                return this.Ok(new { Success = true, Message = "User Note deleted successfully" });
            }
            catch (Exception e)
            {
                return this.BadRequest(new { Success = false, Message = e.Message });
            }
        }
        [Authorize]
        [HttpGet("getAllNote")]
        public async Task<IActionResult> GetAllNote()
        {
            try
            {
                int userid = Convert.ToInt32(User.Claims.FirstOrDefault(x => x.Type == "Userid").Value);
                var noteList = new List<Notes>();
                noteList = await noteBL.GetAllNotes(userid);

                return this.Ok(new { Success = true, message = $"GetAll note successfull ", data = noteList });

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}

