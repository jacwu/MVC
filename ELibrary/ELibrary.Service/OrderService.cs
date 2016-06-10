using ELibrary.Data;
using ELibrary.Data.Repositories;
using ELibrary.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELibrary.Service
{
    public class OrderService : IOrderService
    {
        private IOrderRepository orderRepository;
        private IBookRepository bookRepository;

        public OrderService(IOrderRepository orderRepository, IBookRepository bookRepository)
        {
            this.orderRepository = orderRepository;
            this.bookRepository = bookRepository;
        }

        public Order BorrowBook(int bookid)
        {
            Book book = this.bookRepository.GetById(bookid);
            Order order = new Order
            {
                Book = book,
                OpenDate = DateTime.Now,
                UserEmail = "testuser@contoso.com"
            };
            return this.orderRepository.Add(order);
        }

        public void ReturnBook(int orderid)
        {
            Order order = this.orderRepository.GetById(orderid);
            this.orderRepository.Update(order);
            order.CloseDate = DateTime.Now;
        }
    }
}
