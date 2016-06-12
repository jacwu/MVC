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
    [Route("api/library/books/{bookid?}", Name ="Books")]
    public class BooksController : BaseApiController
    {
        private IBookService _bookService;

        public BooksController(IBookService bookService, IModelFactory modelFactory):base(modelFactory)
        {
            _bookService = bookService;
        }
        public IHttpActionResult Get()
        {
            
            return InternalServerError(new NotImplementedException());
        }

    }
}