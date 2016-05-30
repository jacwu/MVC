using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELibrary.Model.Models
{
    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Rating { get; set; }
        public virtual ICollection<Book> Books { get; set; }

    }
}
