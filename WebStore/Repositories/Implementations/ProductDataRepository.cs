using WebStore.Repositories.Interfaces;
using System.Collections.Generic;
using WebStore.Domain.Entities;

namespace WebStore.Repositories.Implementations
{
    /// <summary>
    /// This repository to interact with the database and retrieve data about product sections and product brands
    /// Responsible for adding, deleting and editing information about employees to the database
    /// </summary>
    public class ProductDataRepository : IProductDataRepository
    {        
        private IEnumerable<Section> _sections;
        private IEnumerable<Brand> _brands;
        IEnumerable<Product> _products;

        /// <summary>
        /// This collection located in memory
        /// </summary>
        public IEnumerable<Section> Sections => _sections ?? new List<Section>();               

        /// <summary>
        /// This collection located in memory
        /// </summary>
        public IEnumerable<Brand> Brands => _brands ?? new List<Brand>();        

        /// <summary>
        /// This collection located in memory
        /// </summary>
        public IEnumerable<Product> Products => _products ?? new List<Product>();

        public ProductDataRepository()
        {
            

        }
    }
}