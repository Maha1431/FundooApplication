﻿using CommonLayer.Notes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interface
{
   public interface INoteBL
    {
       Task AddNote(int userId,  NotePostModel notePost);
    }
}