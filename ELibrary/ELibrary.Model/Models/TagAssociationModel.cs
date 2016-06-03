using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELibrary.Model.Models
{
    class TagAssociationModel
    {
        public ICollection<LinkModel> Links { get; set; }
        public string Name { get; set; }
    }
}
