using Microsoft.AspNetCore.Mvc;

namespace WebStore.Controllers
{
    /// <summary>
    /// The main controller. 
    /// The entry point to the site
    /// </summary>
    public class HomeController : Controller
    {
        public IActionResult Index() => View();

        public IActionResult Shop() => View();

        public IActionResult ProductDetails() => View();

        public IActionResult Login() => View();

        public IActionResult Cart() => View();

        public IActionResult Checkout() => View();

        public IActionResult Blog() => View();

        public IActionResult BlogSingle() => View();


    }
}