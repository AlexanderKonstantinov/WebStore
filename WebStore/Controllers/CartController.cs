using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebStore.Domain.Dto.Order;
using WebStore.Domain.Entities;
using WebStore.Domain.Models.Cart;
using WebStore.Domain.Models.Order;
using WebStore.Domain.Models.Product;
using WebStore.Interfaces.Services;

namespace WebStore.Controllers
{
    public class CartController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ICartService _cartService;
        private readonly IOrdersData _ordersData;

        public CartController(ICartService cartService, IOrdersData ordersData, IMapper mapper)
        {
            _mapper = mapper;
            _cartService = cartService;
            _ordersData = ordersData;
        }

        public IActionResult Details()
        {
            var model = new DetailsViewModel()
            {
                CartViewModel = _cartService.TransformCart(),
                OrderViewModel = new OrderViewModel()
            };

            return View(model);
        }

        public IActionResult DecrementFromCart(int id)
        {
            _cartService.DecrementFromCart(id);
            return RedirectToAction("Details");
        }

        public IActionResult RemoveFromCart(int id)
        {
            _cartService.RemoveFromCart(id);
            return RedirectToAction("Details");
        }

        public IActionResult RemoveAll()
        {
            _cartService.RemoveAll();
            return RedirectToAction("Details");
        }

        public IActionResult AddToCart(int id, string returnUrl)
        {
            _cartService.AddToCart(id);
            return Redirect(returnUrl);
        }

        [HttpPost,
         ValidateAntiForgeryToken]
        public IActionResult Checkout(OrderViewModel model)
        {
            if (ModelState.IsValid)
            {
                var createOrder = new CreateOrderModel
                {
                    Address = model.Address,
                    Name = model.Name,
                    Phone = model.Phone,
                    Date = DateTime.Now
                };

                var cartViewModel = _cartService.TransformCart();

                var products = new List<ProductViewModel>(cartViewModel.ItemsCount);

                foreach (var item in cartViewModel.Items)
                {
                    for (int i = item.Value; i > 0; i--)
                        products.Add(item.Key);
                }

                //createOrder.OrderItems = _mapper.Map<OrderItem>(products)

                var orderResult = _ordersData.CreateOrder(createOrder,
                    User.Identity.Name);

                //_cartService.RemoveAll();

                return RedirectToAction("OrderConfirmed", new { id = orderResult.Id });
            }
            var detailsModel = new DetailsViewModel()
            {
                CartViewModel = _cartService.TransformCart(),
                OrderViewModel = model
            };
            return View("Details", detailsModel);
        }

        public IActionResult OrderConfirmed(int id)
        {
            ViewBag.OrderId = id;
            return View();
        }

    }
}