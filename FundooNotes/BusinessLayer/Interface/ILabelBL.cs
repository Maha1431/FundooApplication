using CommonLayer.Label;
using RepositoryLayer.Entities;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interface
{
  public interface ILabelBL
    {
        Task<List<Label>> CreateLabel(int noteId, int Userid, LabelModel labelModel);
        public IEnumerable<Label> GetLabelsByNoteID(int Userid, int noteId);
        bool UpdateLabel(int labelId, LabelModel labelModel);
        bool DeleteLabel(int labelId);
    }
}
