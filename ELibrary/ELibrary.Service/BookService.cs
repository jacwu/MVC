using ELibrary.Data;
using ELibrary.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELibrary.Service
{
    public interface IBookService
    {
        IEnumerable<Book> GetBooks();
    }
    public class BookService: IBookService
    {
        private IBookRepository bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }

        public IEnumerable<Book> GetBooks()
        {
            return this.bookRepository.GetAll();
        }
    }
}
