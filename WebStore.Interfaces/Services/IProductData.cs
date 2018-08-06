using System.Collections.Generic;
using WebStore.Domain.Dto.Product;
using WebStore.Domain.Filters;

namespace WebStore.Interfaces.Services
{
    /// <summary>
    /// Interface describe connecting CatalogController with Database
    /// </summary>
    public interface IProductData
    {
        /// <summary>
        /// Get product sections 
        /// </summary>
        /// <returns></returns>
        IEnumerable<SectionDto> GetSections();

        /// <summary>
        /// Get product brands
        /// </summary>
        /// <returns></returns>
        IEnumerable<BrandDto> GetBrands();

        /// <summary>
        /// Get products
        /// </summary>
        /// <param name="filter">Product filter</param>
        /// <returns></returns>
        IEnumerable<ProductDto> GetProducts(ProductFilter filter);

        /// <summary>
        /// Get product count by brand Id
        /// </summary>
        /// <param name="id">Brand identifier</param>
        /// <returns>Brand product count</returns>
        int GetBrandProductCount(int id);

        /// <summary>
        /// Get product by Id
        /// </summary>
        /// <param name="id">Product identifier</param>
        /// <returns>required product or null if product with such Id does not exist</returns>
        ProductDto GetProductById(int id);
    }
}
