﻿using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebStore.Helpers;
using WebStore.Infrastructure.Interfaces;

namespace WebStore.Areas.Admin.Controllers
{
    [Area("Admin"),
    Authorize(Roles = "Administrator")]
    public class HomeController : Controller
    {
        private readonly IProductData _productData;

        public HomeController(IProductData productData, IMapper mapper)
        {
            _productData = productData;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Route("admin/products")]
        public IActionResult ProductList()
        {
            var products = _productData.GetProducts(new ProductFilter());
            return View(products);
        }

    }
}