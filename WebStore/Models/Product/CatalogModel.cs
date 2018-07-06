using System.Collections.Generic;

namespace WebStore.Models.Product
{
    public class CatalogModel
    {
        public int? BrandId { get; set; }
        public int? SectionId { get; set; }
        public IEnumerable<ProductModel> Products { get; set; }

    }
}
