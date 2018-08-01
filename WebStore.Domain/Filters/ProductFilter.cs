
using System.Collections.Generic;

namespace WebStore.Domain.Filters
{
    /// <summary>
    /// Product filter
    /// </summary>
    public class ProductFilter
    {
        /// <summary>
        /// Product section Id
        /// </summary>
        public int? SectionId { get; set; }

        /// <summary>
        /// Product brand Id
        /// </summary>
        public int? BrandId { get; set; }

        public IList<int> Ids { get; set; }
    }

}
