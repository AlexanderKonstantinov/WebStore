using System.Collections.Generic;
using System.Linq;
using WebStore.Models.Product;

namespace WebStore.Models.Cart
{
    public class CartViewModel
    {
        public Dictionary<ProductViewModel, int> Items { get; set; }

        public int ItemsCount => Items?.Sum(x => x.Value) ?? 0;
    }
}
