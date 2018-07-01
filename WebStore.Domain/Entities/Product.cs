using WebStore.Domain.Entities.Base;

namespace WebStore.Domain.Entities
{
    /// <summary>
    /// Product entity
    /// </summary>
    public class Product : OrderNamedEntity
    {
        /// <summary>
        /// Section Id of product
        /// </summary>
        public int SectionId { get; set; }

        /// <summary>
        /// Brand Id of product
        /// </summary>
        public int? BrandId { get; set; }

        /// <summary>
        /// Product image link
        /// </summary>
        public string ImageUrl { get; set; }


        /// <summary>
        /// Product price
        /// </summary>
        public decimal Price { get; set; }
    }
}
