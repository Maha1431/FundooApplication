using CommonLayer.Label;
using RepositoryLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Interface
{
    public interface ILabelRL
    {
        Task<List<Label>> CreateLabel(int noteId, int Userid, LabelModel labelModel);
        Task<List<LabelResponse>> GetAllLabels(int Userid);
        bool UpdateLabel(int labelId, LabelModel labelModel);
        bool DeleteLabel(int labelId);
        Task<List<Label>> GetLabelsBynoteId(int Userid, int noteId);



    }
}
