using ELibrary.Model.Entities;
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

        [Required]
        [Display(Name = "Author Name")]
        public string AuthorName { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 10)]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Publish Year")]
        public int PublishYear { get; set; }

        [Required]
        public string Snapshot { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        [Display(Name = "Category")]
        public int TagId { get; set; }


    }
}