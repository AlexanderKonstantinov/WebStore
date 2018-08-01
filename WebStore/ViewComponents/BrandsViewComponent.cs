using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using WebStore.Domain.Models.Product;
using WebStore.Interfaces.Services;

namespace WebStore.ViewComponents
{
    public class BrandsViewComponent : ViewComponent
    {
        private readonly IProductData _productData;

        public BrandsViewComponent(IProductData productData)
        {
            _productData = productData;
        }

        public IViewComponentResult Invoke()
        {
            var model = GetBrands();
            return View(model);
        }

        private IEnumerable<BrandViewModel> GetBrands()
        {
            // Может как-то одним выражением это можно записать?
            var brands = _productData.GetBrands()
                .Select(b => new BrandViewModel
                {
                    Id = b.Id,
                    Name = b.Name,
                    Order = b.Order,
                    ProductsCount = 0
                }).ToList();

            for (int i = 0; i < brands.Count; i++)
                brands[i].ProductsCount = _productData.GetBrandProductCount(brands[i].Id);

            return brands;
        }

    }
}
