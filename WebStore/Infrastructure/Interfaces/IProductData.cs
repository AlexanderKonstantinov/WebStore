using System.Collections.Generic;
using WebStore.Domain.Entities;

namespace WebStore.Infrastructure.Interfaces
{
    /// <summary>
    /// Interface describe connecting CatalogController with CatalogRepository
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
    }
}
