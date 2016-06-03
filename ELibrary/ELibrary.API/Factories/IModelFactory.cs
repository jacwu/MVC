using ELibrary.Model.Entities;
using ELibrary.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Routing;

namespace ELibrary.API.Factories
{
    public interface IModelFactory
    {
        TagAssociationModel CreateTagAssociationModel(UrlHelper urlHelper, string routeName, Tag tag);
    }
}
