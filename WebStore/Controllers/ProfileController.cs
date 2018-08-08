using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebStore.Domain.Models.Order;
using WebStore.Interfaces.Services;

namespace WebStore.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IOrdersData _ordersData;
        public ProfileController(IOrdersData ordersData, IMapper mapper)
        {

            _mapper = mapper;
            _ordersData = ordersData;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Orders()
        {
            var orders = _ordersData.GetUserOrders(User.Identity.Name);

            var orderModels = _mapper.Map<IEnumerable<UserOrderViewModel>>(orders);

            //var orderModels = new List<UserOrderViewModel>(orders.Count());

            //foreach (var order in orders)
            //{
            //    orderModels.Add(new UserOrderViewModel()
            //    {
            //        Id = order.Id,
            //        Name = order.Name,
            //        Address = order.Address,
            //        Phone = order.Phone,
            //        TotalSum = order.OrderItems.Sum(o => o.Price * o.Quantity)
            //    });
            //}
            return View(orderModels);
        }
    }
}