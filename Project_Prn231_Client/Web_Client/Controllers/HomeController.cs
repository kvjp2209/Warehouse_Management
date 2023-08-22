using Microsoft.AspNetCore.Mvc;

namespace Web_Client.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
