﻿using System;
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
        private IImageUrlGenerator _imageUrlGenerator;
        private IImagePrefixProvider _imageUrlPrefixProvider;

        public ModelFactory(IImageUrlGenerator imageUrlGenerator, IImagePrefixProvider imageUrlPrefixProvider)
        {
            _imageUrlGenerator = imageUrlGenerator;
            _imageUrlPrefixProvider = imageUrlPrefixProvider;
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
                ImageName = tag.ImageName,
                ImageUrl = _imageUrlGenerator.CreateTagImageUrl(_imageUrlPrefixProvider.TagImagePrefix(), tag.ImageName)
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
                ImageUrl = _imageUrlGenerator.CreateTagImageUrl(_imageUrlPrefixProvider.TagImagePrefix(), tag.ImageName),
                Books = tag.Books.Select(m=>CreateBookAssociationModel(urlHelper, "Books", m))
            };
        }

        public BookAssociationModel CreateBookAssociationModel(UrlHelper urlHelper, string routeName, Book book)
        {
            return new BookAssociationModel
            {
                Links = new List<LinkModel>
                {
                    CreateLink(urlHelper.Link(routeName, new {bookId = book.Id }), RelConstant.SELF)
                },
                Title = book.Title,
                Description = book.Description,
                ImageName = book.ImageName,
                ImageUrl = _imageUrlGenerator.CreateBookImageUrl(_imageUrlPrefixProvider.BookImagePrefix(), book.ImageName)
            };
        }
    }
}
