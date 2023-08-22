using Microsoft.AspNetCore.Mvc;

namespace Web_Client.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            ViewData["login"] = true;
            return View();
        }
    }
}
