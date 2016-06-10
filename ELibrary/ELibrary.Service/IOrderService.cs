using ELibrary.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELibrary.Service
{
    public interface IOrderService
    {
        Order BorrowBook(int bookid);
        void ReturnBook(int orderid);
    }
}
