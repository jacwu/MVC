﻿using ELibrary.Model.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ELibrary.Web.ViewModels
{
    public class BookViewModel
    {
        [Required]
        public string Title { get; set; }

        [Display(Name = "Author Name")]
        public string AuthorName { get; set; }

        [Required]
        [StringLength(300, MinimumLength = 5)]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Publish Year")]
        public int PublishYear { get; set; }

        [Display(Name = "Cover")]
        [Required]
        public HttpPostedFileBase CoverImg { get; set; }

        [Required]
        [Display(Name = "Category")]
        public IEnumerable<int> TagIds { get; set; }


    }
}