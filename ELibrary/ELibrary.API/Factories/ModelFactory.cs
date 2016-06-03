using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ELibrary.Model.Entities;
using ELibrary.Model.Models;
using System.Web.Http.Routing;

namespace ELibrary.API.Factories
{
    class ModelFactory : IModelFactory
    {
        LinkModel CreateLink(string href, string rel, string method="GET")
        {
            return new LinkModel
            {
                Href = href,
                Rel = rel,
                Method = method
            };
        }
        public TagAssociationModel CreateTagAssociationModel(UrlHelper urlHelper, string routeName, Tag tag)
        {
            return new TagAssociationModel
            {
                Links = new List<LinkModel>
                {
                    CreateLink(urlHelper.Link(routeName, new { }), "SELF")
                },
                Name = tag.Name
            };
        }
    }
}
