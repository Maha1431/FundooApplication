using BusinessLayer.Interface;
using CommonLayer.Label;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RepositoryLayer.Entities;
using RepositoryLayer.Services;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FundooNotes.Controllers
{

    [ApiController]
    [Route("[Controller]")]
    public class LabelController : ControllerBase
    {
        ILabelBL labelBL;
        FundooNotesDbContext DbContext;
        public LabelController(ILabelBL labelBL, FundooNotesDbContext DbContext)
        {
            this.labelBL = labelBL;
            this.DbContext = DbContext;
        }

        [Authorize]
        [HttpPost("createlabel")]
        public async Task<IActionResult> CreateLabel(LabelModel labelModel, int noteId)
        {
            try
            {
                // int userID = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "userid").Value);
                var userId = User.Claims.FirstOrDefault(x => x.Type.ToString().Equals("Userid", StringComparison.InvariantCultureIgnoreCase));
                int UserId = Int32.Parse(userId.Value);

                List<Label> labels = new List<Label>();

                labels = await labelBL.CreateLabel(UserId, noteId, labelModel);

                return this.Ok(new { success = true, message = "Label added successfully", response = labelModel, noteId });

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        [Authorize]
        [HttpGet("GetLabelsByNoteID/{noteId}")]
        public IEnumerable GetLabelsByNoteID(int noteId)
        {
            try
            {
                int userId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "Userid").Value);
                return labelBL.GetLabelsByNoteID(userId, noteId);
            }
            catch (Exception)
            {

                throw;
            }
        }
       // [Authorize]
        [HttpPut("updateLabel/{labelId}")]

        public IActionResult UpdateNotes(int labelId, LabelModel labelModel)
        {
            try
            {
                if (labelBL.UpdateLabel(labelId, labelModel))
                {
                    return this.Ok(new { Success = true, message = "Labels updated successfully", response = labelId, labelModel });
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
        [HttpDelete("deletelabel/{labelId}")]
        public IActionResult DeleteLabel(int labelId)
        {
            try
            {
                if (labelBL.DeleteLabel(labelId))
                {
                    return this.Ok(new { Success = true, message = "Labels deleted successfully" });

                }
                else
                {
                    return this.BadRequest(new { Success = false, message = "Labels with given ID not found" });
                }

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}








        

