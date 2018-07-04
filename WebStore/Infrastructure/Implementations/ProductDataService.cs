using System.Collections.Generic;
using System.Linq;
using WebStore.Domain.Entities;
using WebStore.Helpers;
using WebStore.Infrastructure.Interfaces;
using WebStore.Repositories.Interfaces;

namespace WebStore.Infrastructure.Implementations
{
    /// <summary>
    /// Layer between CatalogController and CatalogRepository
    /// Responsible for getting, updating for controller and view data transfer to the repository 
    /// </summary>
    public class ProductDataService 
    {
        private readonly IProductDataRepository _productDataRepository;

        public ProductDataService(IProductDataRepository productDataRepository)
        {
            _productDataRepository = productDataRepository;
        }

        public IEnumerable<Brand> GetBrands() => _productDataRepository.Brands;
        
        public IEnumerable<Section> GetSections() => _productDataRepository.Sections;

        public IEnumerable<Product> GetProducts(ProductFilter filter)
        {
            var products = _productDataRepository.Products;

            if (filter.SectionId.HasValue)
                products = products.Where(p => p.SectionId.Equals(filter.SectionId)).ToList();

            if (filter.BrandId.HasValue)
                products = products.Where(p => p.BrandId.HasValue 
                && p.BrandId.Value.Equals(filter.BrandId.Value)).ToList();

            return products;
        }

        public IEnumerable<Product> GetProducts() => _productDataRepository.Products;

        public int GetBrandProductCount(int id)
        {
            int count = _productDataRepository.Products.Count(p => p.BrandId == id);

            return count;
        }
    }
}
