﻿using ELibrary.Data.Repositories;
using ELibrary.Model.Entities;
using System;
using System.Linq;

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

        public Order BorrowBook(int bookid, string userName)
        {
            Book book = this.bookRepository.GetById(bookid);
            Order order = new Order
            {
                Book = book,
                OpenDate = DateTime.Now,
                UserName = userName
            };
            return this.orderRepository.Add(order);
        }

        public void ReturnBook(int orderid)
        {
            Order order = this.orderRepository.GetById(orderid);
            this.orderRepository.Update(order);
            order.CloseDate = DateTime.Now;
        }

        public IQueryable<Order> GetOpenOrders(string userName)
        {
            return orderRepository.GetOpenOrders(userName);
        }
    }
}
