using System.Collections.Generic;
using System.Linq;
using ELibrary.Data;
using ELibrary.Model.Entities;

namespace ELibrary.Service
{
    public class TagService : ITagService
    {
        private IEnumerable<Tag> allTags;
        public IEnumerable<Tag> AllTags
        {
            get
            {
                if(null == allTags)
                {
                    allTags = tagRepository.GetAll();
                }

                return allTags;
            }
        }

        private ITagRepository tagRepository;

        public TagService(ITagRepository tagRepository)
        {
            this.tagRepository = tagRepository;
        }


        public Tag GetTag(int id)
        {
            return tagRepository.GetById(id);
        }

        public IEnumerable<Tag> GetTagsForBook(int bookId)
        {
            return tagRepository.GetTagsForBook(bookId);
        }
    }
}
