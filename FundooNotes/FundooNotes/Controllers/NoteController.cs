using BusinessLayer.Interface;
using CommonLayer.Notes;
using Microsoft.AspNetCore.Mvc;
using RepositoryLayer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FundooNotes.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class NoteController : ControllerBase
    {
        INoteBL noteBL;
        FundooNotesDbContext DbContext;
        public NoteController(INoteBL noteBL, FundooNotesDbContext DbContext)
        {
            this.noteBL = noteBL;
            this.DbContext = DbContext;
        }
       /* [HttpPost("register")]
        public async Task<IActionResult> RegisterdNotes (NotePostModel notePost)
        {
            try
            {
                var userId = User.Claims.FirstOrDefault(x => x.Type.ToString().Equals("userId", StringComparison.InvariantCultureIgnoreCase));
                int UserId = Int32.Parse(UserId.Value);
                await this.noteBL.AddNote(notePost,userId);
                return this.Ok(new { success = true, Message = $"Registration is successfull" });
            }
            catch(Exception e)
            {
                throw e;
            }*/
        }
    }

