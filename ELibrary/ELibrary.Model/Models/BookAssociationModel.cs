using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELibrary.Model.Models
{
    public class BookAssociationModel
    {
        public ICollection<LinkModel> Links { get; set; }
        public string Title { get; set; }

        public string Description { get; set; }

        public string AuthorName { get; set; }
        public string ImageName { get; set; }

    }
}
