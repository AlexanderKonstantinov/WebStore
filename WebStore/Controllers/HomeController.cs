using Microsoft.AspNetCore.Mvc;

namespace WebStore.Controllers
{
    /// <summary>
    /// The main controller. 
    /// The entry point to the site
    /// </summary>
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}