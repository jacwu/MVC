using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELibrary.Model.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string AuthorName { get; set; }
        public string Description { get; set; }
        public int PublishYear { get; set; }
        public string Snapshot { get; set; }
        public decimal Price { get; set; }
        public bool Retired { get; set; }
        public virtual ICollection<Tag> Tags { get; set; }
        public virtual ICollection<Order> Orders { get; set; }

    }
}
