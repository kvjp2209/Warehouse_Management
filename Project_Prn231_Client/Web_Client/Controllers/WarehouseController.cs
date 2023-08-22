using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Web_Client.Data.RequestDTO;
using Web_Client.Data;
using Web_Client.Data.ResponseDTO;
using Web_Client.Services;

namespace Web_Client.Controllers
{
    public class WarehouseController : Controller
    {
        public WarehouseController()
        {

        }

        public async Task<IActionResult> Index()
        {
            var client = new ClientService(HttpContext);
            var response = await client.Get<List<WarehouseResponseDTO>>("http://localhost:5299/api/warehouse");
            ViewData.Add("Abc", "data");
            return View(response);
        }

        //add new warehouse
        [HttpGet]
        public async Task<IActionResult> Add([FromQuery] bool? success = null)
        {
            var client = new ClientService(HttpContext);
            ViewData["success"] = success;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> OnPostAdd(WarehouseRequestDTO p)
        {
            var client = new ClientService(HttpContext);
            var res = await client.Post<ApiResponse>("http://localhost:5299/api/warehouse", p);
            if (res?.IsSuccess == true)
            {
                return RedirectToAction("Add", "Warehouse",
                    new { Success = true });
            }
            else
            {
                return RedirectToAction("Add", "Warehouse",
                    new { Success = false });
            }
        }
    }
}
