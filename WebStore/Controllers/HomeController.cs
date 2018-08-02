using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebStore.Interfaces.Clients;
using WebStore.Interfaces.Services;

namespace WebStore.Controllers
{
    /// <summary>
    /// The main controller. 
    /// The entry point to the site
    /// </summary>
    public class HomeController : Controller
    {
        private const int IndexProductCount = 6;

        private readonly IProductData _productData;

        private IValuesService _valuesService;

        public HomeController(IProductData productData, IValuesService valuesService)
        {
            _productData = productData;
            _valuesService = valuesService;
        }

        public async Task<IActionResult>Index()
        {
            var values = await _valuesService.GetAsync();
            return View(values);
        }

        //public IActionResult Index()
        //{
        //    var model = from p in _productData.GetProducts().Take(IndexProductCount)
        //                select new ProductViewModel
        //                {
        //                    Id = p.Id,
        //                    ImageUrl = p.ImageUrl,
        //                    Name = p.Name,
        //                    Order = p.Order,
        //                    Price = p.Price
        //                };

        //    return View(model);
        //}

        public IActionResult Blog() => View();

        public IActionResult BlogSingle() => View();

        public IActionResult Page404() => View();

        public IActionResult Contact() => View();
    }
}