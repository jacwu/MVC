using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ELibrary.Data;
using ELibrary.Model.Entities;

namespace ELibrary.Service
{
    public interface ITagService
    {
        void CreateTag(Tag tag);

        Tag GetTag(int id);

        IEnumerable<Tag> AllTags { get;}
    }
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

        public void CreateTag(Tag tag)
        {
            this.tagRepository.Add(tag);
        }

        public Tag GetTag(int id)
        {
            return tagRepository.GetById(id);
        }
    }
}
