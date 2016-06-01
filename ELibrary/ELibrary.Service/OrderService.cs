using ELibrary.Data;
using ELibrary.Data.Repositories;
using ELibrary.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELibrary.Service
{
    public interface IOrderService
    {
        void CreateOrder(Order order);
    }
    public class OrderService : IOrderService
    {
        private IOrderRepository orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }

        public void CreateOrder(Order order)
        {
            this.orderRepository.Add(order);
        }
    }
}
