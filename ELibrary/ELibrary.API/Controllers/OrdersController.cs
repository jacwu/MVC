using ELibrary.API.Factories;
using ELibrary.Data.Infra;
using ELibrary.Model.Entities;
using ELibrary.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ELibrary.API.Controllers
{
    [Route("api/library/Orders/{orderid?}", Name = "Orders")]
    public class OrdersController :  BaseApiController
    {
        private IOrderService _orderService;
        private IUnitOfWork _unitOfWork;

        public OrdersController(IOrderService orderService,
                                IUnitOfWork unitOfWork,
                                IModelFactory modelFactory) : base(modelFactory)
        {
            _orderService = orderService;
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        [Route("api/library/Books/{bookid}/Borrow")]
        public IHttpActionResult BorrowBook(int bookid)
        {
            Order order = _orderService.BorrowBook(bookid);
            _unitOfWork.Commit();

            return Ok(order);
        }

        [HttpPut]
        [Route("api/library/Orders/{orderid}/return/")]
        public IHttpActionResult ReturnBook(int orderid)
        {
            _orderService.ReturnBook(orderid);
            _unitOfWork.Commit();

            return Ok();
        }
    }
}
