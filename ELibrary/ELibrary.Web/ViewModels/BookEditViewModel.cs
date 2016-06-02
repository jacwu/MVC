using ELibrary.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ELibrary.Web.ViewModels
{
    public class BookEditViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string AuthorName { get; set; }
        public string Description { get; set; }
        public int PublishYear { get; set; }
        public string Snapshot { get; set; }
        public decimal Price { get; set; }
        public bool Retired { get; set; }
        public int TagId { get; set; }

        public List<Tag> TagOptions { get; set; }
        public IEnumerable<SelectListItem> TagOptionItems
        {
            get
            {
                var items = TagOptions.Select(t => new SelectListItem
                {
                    Value = t.Id.ToString(),
                    Text = t.Name
                });
                return items;
            }
        }

    }
}