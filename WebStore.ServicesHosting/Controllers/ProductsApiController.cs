using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WebStore.Domain.Dto.Product;
using WebStore.Domain.Filters;
using WebStore.Interfaces.Services;

namespace WebStore.ServicesHosting.Controllers
{
    [Route("api/products"),
    Produces("application/json"),
    ApiController]
    public class ProductsApiController : ControllerBase, IProductData
    {
        private readonly IProductData _productData;

        public ProductsApiController(IProductData productData)
        {
            _productData = productData;
        }

        //api/products/sections GET
        [HttpGet("sections")]
        public IEnumerable<SectionDto> GetSections() => _productData.GetSections();

        //api/products/brands GET
        [HttpGet("brands")]
        public IEnumerable<BrandDto> GetBrands() => _productData.GetBrands();

        //api/products POST
        [HttpPost, ActionName("Post")]
        public PagedProductDto GetProducts([FromBody]ProductFilter filter) 
            => _productData.GetProducts(filter);

        //api/products/count/id GET
        [HttpGet("count/{id}"), ActionName("Get")]
        public int GetBrandProductCount(int id) => _productData.GetBrandProductCount(id);

        //api/products/id GET
        [HttpGet("{id}"), ActionName("Get")]
        public ProductDto GetProductById(int id) => _productData.GetProductById(id);

        //api/products/brands/id GET
        [HttpGet("brands/{id}"), ActionName("Get")]
        public BrandDto GetBrandById(int id)
            => _productData.GetBrandById(id);

        //api/products/sections/id GET
        [HttpGet("sections/{id}"), ActionName("Get")]
        public SectionDto GetSectionById(int id)
            => _productData.GetSectionById(id);
    }
}