﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELibrary.Model.Models
{
    class TagModel:TagAssociationModel
    {
        public IEnumerable<BookAssociationModel> Books { get; set; }
    }
}
