using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ELibrary.Data;
using ELibrary.Model.Models;

namespace ELibrary.Service
{
    public interface ITagService
    {
        void CreateTag(Tag tag);
    }
    public class TagService : ITagService
    {
        private ITagRepository tagRepository;

        public TagService(ITagRepository tagRepository)
        {
            this.tagRepository = tagRepository;
        }

        public void CreateTag(Tag tag)
        {
            this.tagRepository.Add(tag);
        }

    }
}
