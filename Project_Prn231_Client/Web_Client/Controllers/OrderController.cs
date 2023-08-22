using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Web_Client.Data.RequestDTO;
using Web_Client.Data.ResponseDTO;
using Web_Client.Services;

namespace Web_Client.Controllers
{
    public class OrderController : Controller
    {
        public OrderController()
        {

        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var client = new ClientService(HttpContext);
            var response = await client.Get<List<OrderResponseDTO>>("http://localhost:5299/api/order");
            return View(response);
        }
    }
}
