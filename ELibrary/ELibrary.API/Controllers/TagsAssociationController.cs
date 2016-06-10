using ELibrary.API.Factories;
using ELibrary.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ELibrary.API.Controllers
{
    [Route("api/library/books/{bookid}/tags", Name ="TagsAssociation")]
    public class TagsAssociationController : BaseApiController
    {
        private ITagService _tagService;

        public TagsAssociationController(ITagService tagService, IModelFactory modelFactory):base(modelFactory)
        {
            _tagService = tagService;
        }

        public IHttpActionResult Get(int bookId)
        {
            var results = _tagService.GetTagsForBook(bookId)
                .ToList()
                .Select(f => TheModelFactory.CreateTagBasicModel(Url, "Tags", f));

            return Ok(results);
        }

    }
}