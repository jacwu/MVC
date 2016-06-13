using ELibrary.Model.Entities;
using System.Collections.Generic;
using System.Linq;

namespace ELibrary.Service
{
    public interface ITagService
    {

        Tag GetTag(int id);
        IQueryable<Tag> GetTagsForBook(int bookId);
        IEnumerable<Tag> AllTags { get; }
    }
}
