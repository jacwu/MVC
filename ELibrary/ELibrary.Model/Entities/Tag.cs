using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELibrary.Model.Entities
{
    public class Tag
    {
        public Tag()
        {
            Books = new List<Book>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public int Rating { get; set; }
        public string ImageName { get; set; }
        public virtual ICollection<Book> Books { get; set; }

    }
}
