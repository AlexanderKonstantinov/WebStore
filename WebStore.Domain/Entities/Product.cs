using System.ComponentModel.DataAnnotations.Schema;
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

        [ForeignKey(nameof(SectionId))]
        public virtual Section Section { get; set; }

        /// <summary>
        /// Brand Id of product
        /// </summary>
        public int? BrandId { get; set; }

        [ForeignKey(nameof(BrandId))]
        public virtual Brand Brand { get; set; }
        
        /// <summary>
        /// Product image link
        /// </summary>
        public string ImageUrl { get; set; }


        /// <summary>
        /// Product price
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Quantity in stock
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Product state
        /// </summary>
        public string Condition { get; set; }
    }
}
