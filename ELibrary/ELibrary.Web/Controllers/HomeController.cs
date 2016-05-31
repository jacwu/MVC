using ELibrary.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ELibrary.Web.Controllers
{
    public class HomeController : Controller
    {
        private IBookService bookService;

        public HomeController(IBookService bookService)
        {
            this.bookService = bookService;
        }

        // GET: Home
        public ActionResult Index()
        {
            
            return View(this.bookService.GetBooks());
        }

        
    }
}
