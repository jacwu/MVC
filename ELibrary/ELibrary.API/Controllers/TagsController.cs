using ELibrary.Service;
using System.Linq;
using System.Web.Http;
using ELibrary.API.Factories;

namespace ELibrary.API.Controllers
{
    [Route("api/library/tags/{tagid?}", Name ="Tags")]
    public class TagsController : BaseApiController
    {
        private ITagService _tagService;

        public TagsController(ITagService tagService, IModelFactory modelFactory):base(modelFactory)
        {
            _tagService = tagService;
        }

        public IHttpActionResult Get()
        {
            
            var results = _tagService.AllTags.Select(t => TheModelFactory.CreateTagBasicModel(Url, "Tags", t));

            return Ok(results);
        }

        public IHttpActionResult Get(int tagId)
        {
            var result = _tagService.GetTag(tagId);

            if (result != null)
                return Ok(TheModelFactory.CreateTagModel(Url, "Tags", result));


            return NotFound();
        }
    }
}
