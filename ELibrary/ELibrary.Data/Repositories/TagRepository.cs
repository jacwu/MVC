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
    }

    public class TagRepository : RepositoryBase<Tag>, ITagRepository
    {
        public TagRepository(IDbFactory dbFactory)
            : base(dbFactory) { }

        public override Tag GetById(int id)
        {
            return DbContext.Tags.Include("Books").Where(f=>f.Id==id).FirstOrDefault(); 
        }

        public IQueryable<Tag> GetTagsForBook(int bookId)
        {
            return DbContext.Tags.Include("Books")
                .Where(f=>f.Books.Any(m=>m.Id==bookId));

        }
    }
}
