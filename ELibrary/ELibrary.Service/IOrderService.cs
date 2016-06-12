﻿using ELibrary.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELibrary.Service
{
    public interface IOrderService
    {
        Order BorrowBook(int bookid, string userName);
        void ReturnBook(int orderid);
        IQueryable<Order> GetOpenOrders(string userName);
    }
}
