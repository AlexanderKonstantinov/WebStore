using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using WebStore.Domain.Filters;
using WebStore.Domain.Models.Cart;
using WebStore.Domain.Models.Product;
using WebStore.Interfaces.Services;

namespace WebStore.Services
{
    public class CookieCartService : ICartService
    {
        private readonly IProductData _productData;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly string _cartName;

        private Cart Cart
        {
            get
            {
                var cookie = _httpContextAccessor.HttpContext.Request.Cookies[_cartName];
                string json = String.Empty;
                Cart cart = null;

                if (cookie == null)
                {
                    cart = new Cart {Items = new List<CartItem>()};
                    json = JsonConvert.SerializeObject(cart);
                    _httpContextAccessor.HttpContext.Response.Cookies.Append(_cartName,
                        json,
                        new CookieOptions
                        {
                            Expires = DateTime.Now.AddDays(1)
                        });
                    return cart;
                }

                json = cookie;
                cart = JsonConvert.DeserializeObject<Cart>(json);

                _httpContextAccessor.HttpContext.Response.Cookies.Delete(_cartName);

                _httpContextAccessor.HttpContext.Response.Cookies.Append(_cartName,
                    json,
                    new CookieOptions
                    {
                        Expires = DateTime.Now.AddDays(1)
                    });

                return cart;
            }
            set
            {
                var json = JsonConvert.SerializeObject(value);

                _httpContextAccessor.HttpContext.Response.Cookies.Delete(_cartName);

                _httpContextAccessor.HttpContext.Response.Cookies.Append(_cartName,
                    json,
                    new CookieOptions
                    {
                        Expires = DateTime.Now.AddDays(1)
                    });
            }
        }

        public CookieCartService(IProductData productData, IHttpContextAccessor httpContextAccessor)
        {
            _productData = productData;
            _httpContextAccessor = httpContextAccessor;
            _cartName = "cart" + (_httpContextAccessor.HttpContext.User.Identity.IsAuthenticated
                            ? _httpContextAccessor.HttpContext.User.Identity.Name
                            : "");
        }

        public void DecrementFromCart(int id)
        {
            var cart = Cart;
            var item = cart.Items.FirstOrDefault(x => x.ProductId == id);

            if (item != null)
            {
                if (item.Quantity > 0)
                    --item.Quantity;

                if (item.Quantity == 0)
                    cart.Items.Remove(item);
            }

            Cart = cart;
        }

        public void RemoveFromCart(int id)
        {
            var cart = Cart;
            var item = cart.Items.FirstOrDefault(x => x.ProductId == id);

            if (item != null)
                cart.Items.Remove(item);

            Cart = cart;
        }

        public void RemoveAll()
        {
            Cart = new Cart { Items = new List<CartItem>() };
        }

        public void AddToCart(int id)
        {
            var cart = Cart;
            var item = cart.Items.FirstOrDefault(x => x.ProductId == id);

            if (item != null)
                ++item.Quantity;
            else
                cart.Items.Add(new CartItem { ProductId = id, Quantity = 1} );

            Cart = cart;
        }

        public CartViewModel TransformCart()
        {
            // Не знаю как тут лучше маппинг использовать. Получать экземпляр IMapper В конструкторе?

            //var products = _mapper.Map<IEnumerable<ProductViewModel>>(
            //    _productData.GetProducts(new ProductFilter
            //    {
            //        Ids = Cart.Items.Select(i => i.ProductId).ToList()
            //    }));

            var products = _productData.GetProducts(new ProductFilter
            {
                Ids = Cart.Items.Select(i => i.ProductId).ToList()
            });

            var productViewModelList = products.Select(p => new ProductViewModel
                {
                    Price = p.Price,
                    Quantity = p.Quantity,
                    Id = p.Id,
                    Brand = p.Brand is null ? String.Empty : p.Brand.Name,
                    Condition = p.Condition,
                    ImageUrl = p.ImageUrl,
                    Name = p.Name,
                    Order = p.Order
                }
            );

            var cartViewModel = new CartViewModel
            {
                Items = Cart.Items.ToDictionary(
                    x => productViewModelList.First(y => y.Id == x.ProductId),
                    x => x.Quantity)
            };

            return cartViewModel;
        }
    }
}
