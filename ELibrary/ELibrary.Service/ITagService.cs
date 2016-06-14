using ELibrary.Model.Entities;
using System.Collections.Generic;
using System.Linq;

namespace ELibrary.Service
{
    public interface ITagService
    {
        Tag GetTag(int id);
        IEnumerable<Tag> GetTagsForBook(int bookId);
        IEnumerable<Tag> AllTags { get; }
    }
}
