using ELibrary.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELibrary.Data
{
    public interface IBookRepository : IRepository<Book>
    {
    }

    public class BookRepository : RepositoryBase<Book>, IBookRepository
    {
        public BookRepository()
            : base() { }

        
    }


}
