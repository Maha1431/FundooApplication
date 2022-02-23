using BusinessLayer.Interface;
using CommonLayer.Collabrator;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RepositoryLayer.Entities;
using RepositoryLayer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FundooNotes.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class CollabController : ControllerBase
    {
        ICollabBL collabaratorBL;
        FundooNotesDbContext DbContext;
        public CollabController(ICollabBL collabaratorBL, FundooNotesDbContext DbContext)
        {
            this.collabaratorBL = collabaratorBL;
            this.DbContext = DbContext;
        }
        [Authorize]
        [HttpPost("addCollabartor")]
        public async Task<IActionResult> AddCollabrator(int noteId, CollabratorPostModel postModel)
        {
            try
            {
                var userId = User.Claims.FirstOrDefault(x => x.Type.ToString().Equals("Userid", StringComparison.InvariantCultureIgnoreCase));
                int UserId = Int32.Parse(userId.Value);


                await collabaratorBL.AddCollabrator(UserId,noteId,postModel);

                return this.Ok(new { success = true, message = "Collabartion added successfully", response = noteId, postModel});

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        [Authorize]
        [HttpGet("getAllCollabsbynoteId/{noteId}")]
        public async Task<IActionResult> GetAllCollabsbynoteId(int noteId)
        {

            try
            {
                int userID = Convert.ToInt32(User.Claims.FirstOrDefault(x => x.Type == "Userid").Value);

                var CollabrationList = new List<Collabarator>();
                CollabrationList = await collabaratorBL.GetAllCollabsbynoteId(userID,noteId);

                return this.Ok(new { Success = true, message = $"GetAll Collab of Userid={userID} ", data = CollabrationList });


            }
            catch (Exception)
            {

                throw;
            }
        }
        [Authorize]
        [HttpDelete("deleteCollabs/{CollabId}")]
        public async Task<IActionResult> RemoveCollabs(int CollabId)
        {
            try
            {
                var userId = User.Claims.FirstOrDefault(x => x.Type.ToString().Equals("Userid", StringComparison.InvariantCultureIgnoreCase));
                int UserId = Int32.Parse(userId.Value);

                await collabaratorBL.RemoveCollab(CollabId, UserId);

                return this.Ok(new { success = true, message = "Collabartion deleted successfully", response = CollabId });

            }
            catch(Exception e)
            {
                throw e;
            }
        }
    }
}
