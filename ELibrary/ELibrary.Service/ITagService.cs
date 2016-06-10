using ELibrary.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELibrary.Service
{
    public interface ITagService
    {
        void CreateTag(Tag tag);
        Tag GetTag(int id);
        IQueryable<Tag> GetTagsForBook(int bookId);
        IEnumerable<Tag> AllTags { get; }
    }
}
