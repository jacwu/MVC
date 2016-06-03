using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELibrary.Model.Models
{
    public class TagAssociationModel
    {
        public ICollection<LinkModel> Links { get; set; }
        public string Name { get; set; }
        public string ImageName { get; set; }
        public string ImageUrl { get; set; }
    }
}
