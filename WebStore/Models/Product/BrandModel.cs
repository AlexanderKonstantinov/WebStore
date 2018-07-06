using WebStore.Domain.Entities.Base.Interfaces;

namespace WebStore.Models.Product
{
    public class BrandModel : IOrderedEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Order { get; set; }

        /// <summary>
        /// Count brand products
        /// </summary>
        public int ProductsCount { get; set; }        
    }
}
