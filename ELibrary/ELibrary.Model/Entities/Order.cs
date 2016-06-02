using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELibrary.Model.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime OpenDate { get; set; }
        public DateTime CloseDate { get; set; }
        public string UserEmail { get; set; }
        public Book Book { get; set; }
    }
}
