using ELibrary.API.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Principal;
using System.Web.Http;

namespace ELibrary.API.Controllers
{
    public abstract class BaseApiController : ApiController
    {
        private IModelFactory _modelFactory;

        public IModelFactory TheModelFactory
        {
            get
            {
                return _modelFactory;
            }
        }

        public BaseApiController(IModelFactory modelFactory)
        {
            _modelFactory = modelFactory;

            //User = new GenericPrincipal(new GenericIdentity("testuser"), null);
        }
    }
}
