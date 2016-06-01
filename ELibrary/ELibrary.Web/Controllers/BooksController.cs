using ELibrary.Data.Infra;
using ELibrary.Model.Models;
using ELibrary.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ELibrary.Web.Controllers
{
    public class BooksController : Controller
    {
        private IBookService bookService;
        private IUnitOfWork unitOfWork;

        public BooksController(IBookService bookService, IUnitOfWork unitOfWork)
        {
            this.bookService = bookService;
            this.unitOfWork = unitOfWork;
        }

        // GET: Home
        public ActionResult Index()
        {
            
            return View(this.bookService.GetBooks());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Book book)
        {
            if (ModelState.IsValid)
            {
                this.bookService.CreateBook(book);
                this.unitOfWork.Commit();
                
                return RedirectToAction("Index");
            }

            return View(book);
        }


    }
}
