using ELibrary.Data.Infra;
using ELibrary.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace ELibrary.Data
{
    public interface ITagRepository : IRepository<Tag>
    {
        IQueryable<Tag> GetTagsForBook(int bookId);
        Tag GetById(int id, bool availableOnly = true);

    }

    public class TagRepository : RepositoryBase<Tag>, ITagRepository
    {
        public TagRepository(IDbFactory dbFactory)
            : base(dbFactory) { }

        public Tag GetById(int id, bool availableOnly = true)
        {
            if(availableOnly)
            {
                //https://blogs.msdn.microsoft.com/alexj/2009/10/12/tip-37-how-to-do-a-conditional-include/
                //many to many relationship between tag and books
                //http://stackoverflow.com/questions/16798796/ef-include-with-where-clause
                //
                var dbquery = DbContext.Tags.Where(f => f.Id == id).Select(
                    b => new
                    {
                        b,
                        Books = b.Books.Where(p => p.Orders.Where(o => o.CloseDate == null).Count() == 0)
                    })
                    .ToList();

                foreach (var x in dbquery)
                {
                    x.b.Books = (ICollection<Book>)x.Books;
                }

                var result = dbquery.Select(x=>x.b).SingleOrDefault();

                return result;
            }
            else
                return DbContext.Tags.Include("Books").Where(f=>f.Id==id).FirstOrDefault(); 
        }

        public IQueryable<Tag> GetTagsForBook(int bookId)
        {
            return DbContext.Tags.Include("Books")
                .Where(f=>f.Books.Any(m=>m.Id==bookId));

        }
    }
}
