using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using AutoMapper;
using WebStore.Helpers;
using WebStore.Infrastructure.Interfaces;
using WebStore.Models.Product;

namespace WebStore.Controllers
{
    public class CatalogController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IProductData _productData;

        public CatalogController(IProductData productData, IMapper mapper)
        {
            _productData = productData;
            _mapper = mapper;
        }

        public IActionResult Shop(int? sectionId, int? brandId)
        {
            var products = _productData.GetProducts(new ProductFilter
            {
                BrandId = brandId,
                SectionId = sectionId
            });

            var model = new CatalogViewModel()
            {
                BrandId = brandId,
                SectionId = sectionId,
                Products = _mapper.Map<IEnumerable<ProductViewModel>>(products)
                    .OrderBy(p => p.Order)
                    .ToList()
            };

            return View(model);
        }

        public IActionResult ProductDetails(int id)
        {
            var product = _productData.GetProductById(id);

            if (product == null)
                return NotFound();

            var model = _mapper.Map<ProductViewModel>(product);

            return View(model);
        }
    }
}