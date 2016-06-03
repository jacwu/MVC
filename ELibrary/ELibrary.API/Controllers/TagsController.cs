using ELibrary.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ELibrary.Model.Models;
using ELibrary.API.Factories;

namespace ELibrary.API.Controllers
{
    [Route("api/library/tags/{id?}", Name ="Tags")]
    public class TagsController : BaseApiController
    {
        private ITagService _tagService;

        public TagsController(ITagService tagService, IModelFactory modelFactory):base(modelFactory)
        {
            _tagService = tagService;
        }

        public IHttpActionResult Get()
        {
            var route = this.ControllerContext.RouteData.Route;
            var results = _tagService.AllTags.ToList()
                .Select(t => TheModelFactory.CreateTagAssociationModel(Url, "Tags", t));

            return Ok(results);
        }
    }
}
