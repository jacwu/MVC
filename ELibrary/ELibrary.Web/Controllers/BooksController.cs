using AutoMapper;
using ELibrary.Data.Infra;
using ELibrary.Model.Entities;
using ELibrary.Service;
using ELibrary.Web.ViewModels;
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
        private ITagService tagService;
        private IUnitOfWork unitOfWork;

        public BooksController(IBookService bookService, 
            ITagService tagService,
            IUnitOfWork unitOfWork)
        {
            this.bookService = bookService;
            this.tagService = tagService;
            this.unitOfWork = unitOfWork;
        }

        // GET: Home
        public ActionResult Index()
        {
            
            return View(this.bookService.GetBooks());
        }

        public ActionResult Create()
        {
            var v = this.bookService.GetBookwithTag();

            var items = this.tagService.AllTags.Select(t => new SelectListItem
            {
                Value = t.Id.ToString(),
                Text = t.Name
            });
           
            ViewBag.TagOptions = items;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BookViewModel bookViewModel)
        {
            if (ModelState.IsValid)
            {
                if (null != bookViewModel.CoverImg)
                {
                    string uploadedPic = System.IO.Path.GetFileName(bookViewModel.CoverImg.FileName);
                    string localPath = System.IO.Path.Combine(Server.MapPath("~/Content/BookImg"), uploadedPic);
                    bookViewModel.CoverImg.SaveAs(localPath);

                    Book book = Mapper.Map<Book>(bookViewModel);
                    book.Tags = bookViewModel.TagIds.SelectMany(id => this.tagService.AllTags.Where(tag => tag.Id == id)).ToList();
                    
                    book.Snapshot = uploadedPic;
                    this.bookService.CreateBook(book);

                    this.unitOfWork.Commit();

                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("screenshot", "cover image is needed");
                }
            }

            return View(bookViewModel);
        }


    }
}
