using ELibrary.Data.Infra;
using ELibrary.Model.Entities;

namespace ELibrary.Data.Repositories
{
    public interface IBookRepository : IRepository<Book>
    {

    }

    public class BookRepository : RepositoryBase<Book>, IBookRepository
    {
        public BookRepository(IDbFactory dbFactory)
            : base(dbFactory) { }


    }


}
