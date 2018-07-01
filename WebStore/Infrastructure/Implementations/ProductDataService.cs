using System.Collections.Generic;
using WebStore.Domain.Entities;
using WebStore.Infrastructure.Interfaces;
using WebStore.Repositories.Interfaces;

namespace WebStore.Infrastructure.Implementations
{
    /// <summary>
    /// Layer between CatalogController and CatalogRepository
    /// Responsible for getting, updating for controller and view data transfer to the repository 
    /// </summary>
    public class ProductDataService : IProductData
    {
        private readonly IProductDataRepository _productDataRepository;

        public ProductDataService(IProductDataRepository productDataRepository)
        {
            _productDataRepository = productDataRepository;
        }

        public IEnumerable<Brand> GetBrands() => _productDataRepository.Brands;

        public IEnumerable<Section> GetSections() => _productDataRepository.Sections;


    }
}
