﻿using Microsoft.AspNetCore.Mvc;
using System.Linq;
using WebStore.Domain.Models.Product;
using WebStore.Interfaces.Services;

namespace WebStore.Controllers
{
    /// <summary>
    /// The main controller. 
    /// The entry point to the site
    /// </summary>
    public class HomeController : Controller
    {
        private const int IndexProductCount = 6;

        private readonly IProductData _productData;

        public HomeController(IProductData productData)
        {
            _productData = productData;
        }
        
        public IActionResult Index()
        {
            var model = from p in _productData.GetProducts().Take(IndexProductCount)
                        select new ProductViewModel
                        {
                            Id = p.Id,
                            ImageUrl = p.ImageUrl,
                            Name = p.Name,
                            Order = p.Order,
                            Price = p.Price
                        };

            return View(model);
        }

        public IActionResult Blog() => View();

        public IActionResult BlogSingle() => View();

        public IActionResult Page404() => View();

        public IActionResult Contact() => View();
    }
}