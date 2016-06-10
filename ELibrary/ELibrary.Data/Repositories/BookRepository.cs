using ELibrary.Data.Infra;
using ELibrary.Model.Entities;
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
        IEnumerable<Book> GetUnAvailableBook();
    }

    public class BookRepository : RepositoryBase<Book>, IBookRepository
    {
        public BookRepository(IDbFactory dbFactory)
            : base(dbFactory) { }

        public IEnumerable<Book> GetBookwithTag()
        {
            return DbContext.Books.Include("Tags").Where(b => b.Orders.Where(o => o.CloseDate == null).Count() == 0);
        }

        public IEnumerable<Book> GetUnAvailableBook()
        {
            return DbContext.Books.Where(b => b.Orders.Where(o => o.CloseDate == null).Count() > 0).ToList();
        }
    }


}
