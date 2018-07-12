using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using WebStore.DAL.Context;
using WebStore.Domain.Entities;
using WebStore.Helpers;
using WebStore.Infrastructure.Interfaces;

namespace WebStore.Infrastructure.Implementations
{
    /// <summary>
    /// Layer between CatalogController and Database
    /// Responsible for getting, updating for controller and view data transfer to the database 
    /// </summary>
    public class SqlProductData : IProductData
    {
        private readonly WebStoreContext _context;

        public SqlProductData(WebStoreContext context)
        {
            _context = context;
        }

        public IEnumerable<Brand> GetBrands()
            => _context.Brands.ToList();

        public IEnumerable<Product> GetProducts()
            => _context.Products.ToList();

        public IEnumerable<Product> GetProducts(ProductFilter filter)
        {
            var query = _context.Products
                .Include(nameof(Brand))
                .Include(nameof(Section))
                .AsQueryable();

            if (filter.BrandId.HasValue)
                query = query.Where(p => p.BrandId.HasValue
                && p.BrandId.Value.Equals(filter.BrandId.Value));

            if (filter.SectionId.HasValue)
                query = query.Where(p => p.SectionId.Equals(filter.SectionId));

            return query.ToList();
        }

        public IEnumerable<Section> GetSections()
            => _context.Sections.ToList();
        
        public int GetBrandProductCount(int id)
            => _context.Products.Count(p => p.BrandId.HasValue && p.BrandId.Value == id);

        public Product GetProductById(int id)
            => _context.Products
                .Include(nameof(Brand))
                .Include(nameof(Section))
                .AsQueryable()
                .FirstOrDefault(p => p.Id == id);
    }
}
