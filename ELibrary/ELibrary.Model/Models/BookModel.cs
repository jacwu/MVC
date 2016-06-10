using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELibrary.Model.Models
{
    public class BookModel:BookAssociationModel
    {
        public IEnumerable<TagAssociationModel> Tags { get; set; }
    }
}
