using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ELibrary.Model.Entities;
using ELibrary.Model.Models;
using System.Web.Http.Routing;
using ELibrary.Constant;
using ELibrary.Service;

namespace ELibrary.API.Factories
{
    class ModelFactory : IModelFactory
    {
        public ModelFactory()
        {
        }
        LinkModel CreateLink(string href, string rel, string method= MethodConstant.GET)
        {
            return new LinkModel
            {
                Href = href,
                Rel = rel,
                Method = method
            };
        }
        public TagAssociationModel CreateTagAssociationModel(UrlHelper urlHelper, string routeName, Tag tag)
        {
            return new TagAssociationModel
            {
                Links = new List<LinkModel>
                {
                    CreateLink(urlHelper.Link(routeName, new { tagId = tag.Id }), RelConstant.SELF)
                },
                Name = tag.Name,
                ImageName = tag.ImageName
            };
        }

        public TagModel CreateTagModel(UrlHelper urlHelper, string routeName, Tag tag)
        {
            return new TagModel
            {
                Links = new List<LinkModel>
                {
                    CreateLink(urlHelper.Link(routeName, new { tagId = tag.Id }), RelConstant.SELF)
                },
                Name = tag.Name,
                ImageName = tag.ImageName,
                Books = tag.Books.Select(m=>CreateBookAssociationModel(urlHelper, "Books", m))
            };
        }

        public BookAssociationModel CreateBookAssociationModel(UrlHelper urlHelper, string routeName, Book book)
        {
            return new BookAssociationModel
            {
                Links = new List<LinkModel>
                {
                    CreateLink(urlHelper.Link(routeName, new {bookId = book.Id }), RelConstant.SELF),
                    CreateLink(urlHelper.Link("TagsAssociation", new { bookId = book.Id}), RelConstant.TagsAssociation)
                },
                Title = book.Title,
                Description = book.Description,
                ImageName = book.ImageName,
                AuthorName = book.AuthorName

            };
        }

        public BookModel CreateBookModel(UrlHelper urlHelper, string routeName, Book book)
        {
            return new BookModel
            {
                Links = new List<LinkModel>
                {
                    CreateLink(urlHelper.Link(routeName, new {bookId = book.Id }), RelConstant.SELF)
                },
                Title = book.Title,
                Description = book.Description,
                ImageName = book.ImageName,
                AuthorName = book.AuthorName,
                Tags = book.Tags.Select(m=>CreateTagAssociationModel(urlHelper, "Tags", m))
            };
        }
    }
}
