using System.Collections.Generic;
using System.Linq;
using WebStore.DAL.Context;
using WebStore.Domain.Entities;
using WebStore.Helpers;
using WebStore.Infrastructure.Interfaces;

namespace WebStore.Infrastructure.Implementations
{
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
            var query = _context.Products.AsQueryable();

            if (filter.BrandId.HasValue)
                query = query.Where(p => p.BrandId.HasValue
                && p.BrandId.Value.Equals(filter.BrandId.Value));

            if (filter.SectionId.HasValue)
                query = query.Where(p => p.SectionId.Equals(filter.SectionId));

            return query.ToList();
        }

        public IEnumerable<Section> GetSections()
            => _context.Sections.ToList();

        // Здесь не знаю, будет ли когда нибудь параметр равен null или такое невозможно
        public int GetBrandProductCount(int? id)
            => id.HasValue 
            ? _context.Products.Count(p => p.BrandId.HasValue && p.BrandId.Value == id)
            : 0;
    }
}
