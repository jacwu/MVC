﻿using AutoMapper;
using ELibrary.Data.Infra;
using ELibrary.Model.Models;
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
            //var v = this.bookService.GetBookwithTag();

            //var tag = this.tagService.GetTags().Where(f => f.Name == "C#").FirstOrDefault();
            //bookViewBag.Categories = new MultiSelectList(this.tagService.GetTags(), "Id", "Name", this.bookService.GetBooks().FirstOrDefault().Tags);

            BookEditViewModel viewmodel = new BookEditViewModel();
            viewmodel.TagOptions = this.tagService.GetTags().ToList();
            viewmodel.TagId = viewmodel.TagOptions.First().Id;
            return View(viewmodel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BookEditViewModel bookViewModel)
        {
            if (ModelState.IsValid)
            {
                Book book = Mapper.Map<Book>(bookViewModel);
                book.Tag = this.tagService.GetTag(bookViewModel.TagId);
                this.bookService.CreateBook(book);
                this.unitOfWork.Commit();
                
                return RedirectToAction("Index");
            }

            return View(bookViewModel);
        }


    }
}
