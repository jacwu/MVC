using ELibrary.Data.Infra;
using ELibrary.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELibrary.Data.Repositories
{
    public interface IBookRepository : IRepository<Book>
    {
        IEnumerable<Book> GetBookwithTag();
    }

    public class BookRepository : RepositoryBase<Book>, IBookRepository
    {
        public BookRepository(IDbFactory dbFactory)
            : base(dbFactory) { }

        public IEnumerable<Book> GetBookwithTag()
        {
            return DbContext.Books.Include("Tag").ToList();
        }
    }


}
