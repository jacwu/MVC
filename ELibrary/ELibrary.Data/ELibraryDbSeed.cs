using ELibrary.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Migrations;

namespace ELibrary.Data
{
    class ELibraryDbSeed
    {
        public static void Seed(ELibraryEntities context)
        {
            SeedTags(context);
            SeedBooks(context);
        }

        private static void SeedTags(ELibraryEntities ctx)
        {
            ctx.Tags.AddOrUpdate(x => x.Name,
                new Tag { Name = "Programming" },
                new Tag { Name = "C#" },
                new Tag { Name = ".Net" },
                new Tag { Name = "Software Design & Engineering" },
                new Tag { Name = "Enterprise Applications" },
                new Tag { Name = "Web Design" },
                new Tag { Name = "JavaScript" },
                new Tag { Name = "Data Structures" },
                new Tag { Name = "Windows Server" },
                new Tag { Name = "Unix" }
                );

            ctx.Commit();
        }

        private static void SeedBooks(ELibraryEntities ctx)
        {

            //Add book CLR via C#, Second Edition
            var book = new Book
            {
                Title = "CLR via C#, Second Edition",
                AuthorName = "Jeffrey Richter",
                Description = @"Dig deep and master the intricacies of the common language runtime, C#, and .NET development. Led by programming expert Jeffrey Richter, a longtime consultant to the Microsoft .NET team - you’ll gain pragmatic insights for building robust, reliable, and responsive apps and components.",
                PublishYear = 2006,
                ImageName = "clrviacsharp.jpg",
                Retired = false
            };

            var tag = ctx.Tags.Where(f => f.Name == "C#").FirstOrDefault();

            book.Tags.Add(tag);


            ctx.Books.Add(book);


            //Add book Code Complete: A Practical Handbook of Software Construction, Second Edition
            book = new Book
            {
                Title = "Code Complete: A Practical Handbook of Software Construction, Second Edition",
                AuthorName = "Steve McConnell",
                Description = @"Widely considered one of the best practical guides to programming, Steve McConnell’s original CODE COMPLETE has been helping developers write better software for more than a decade. Now this classic book has been fully updated and revised with leading-edge practices—and hundreds of new code samples—illustrating the art and science of software construction. Capturing the body of knowledge available from research, academia, and everyday commercial practice, McConnell synthesizes the most effective techniques and must-know principles into clear, pragmatic guidance. No matter what your experience level, development environment, or project size, this book will inform and stimulate your thinking—and help you build the highest quality code.",
                PublishYear = 2004,
                ImageName = "codecomplete.jpg",
                Retired = false,
                };

            tag = ctx.Tags.Where(f => f.Name == "Software Design & Engineering").FirstOrDefault();

            book.Tags.Add(tag);

            ctx.Books.Add(book);

            ctx.Commit();
        }
    }
}
