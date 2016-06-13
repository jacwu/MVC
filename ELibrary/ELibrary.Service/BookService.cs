using ELibrary.Data.Repositories;
using ELibrary.Model.Entities;

namespace ELibrary.Service
{
    public class BookService: IBookService
    {
        private IBookRepository bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }

        public void CreateBook(Book book)
        {
            this.bookRepository.Add(book);
        }


    }
}
