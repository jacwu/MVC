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
        IEnumerable<Tag> GetTagsForBook(int bookId);
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
                var dbquery = DbContext.Tags.Where(f => f.Id == id).Select(
                    b => new
                    {
                        b,
                        Books = b.Books.Where(p => p.Orders.Where(o => o.CloseDate == null).Count() == 0)
                    });

                foreach (var x in dbquery)
                {
                    x.b.Books = (ICollection<Book>)x.Books;
                }

                var result = dbquery.Select(x=>x.b).SingleOrDefault();

                return result;
            }
            else
                return DbContext.Tags.Include("Books").Where(t=>t.Id==id).FirstOrDefault(); 
        }

        public IEnumerable<Tag> GetTagsForBook(int bookId)
        {
            return DbContext.Books.Include("Tags").SingleOrDefault(b => b.Id == bookId).Tags;
        }
    }
}
