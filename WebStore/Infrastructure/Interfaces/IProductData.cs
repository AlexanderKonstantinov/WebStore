using System.Collections.Generic;
using WebStore.Domain.Entities;
using WebStore.Helpers;

namespace WebStore.Infrastructure.Interfaces
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
        IEnumerable<Section> GetSections();

        /// <summary>
        /// Get product brands
        /// </summary>
        /// <returns></returns>
        IEnumerable<Brand> GetBrands();

        /// <summary>
        /// Get all products (temporary)
        /// </summary>
        /// <returns></returns>
        IEnumerable<Product> GetProducts();

        /// <summary>
        /// Get products
        /// </summary>
        /// <param name="filter">Product filter</param>
        /// <returns></returns>
        IEnumerable<Product> GetProducts(ProductFilter filter);

        /// <summary>
        /// Get product count by brand Id
        /// </summary>
        /// <param name="id">Brand identifier</param>
        /// <returns>Brand product count</returns>
        int GetBrandProductCount(int? id);
    }
}
