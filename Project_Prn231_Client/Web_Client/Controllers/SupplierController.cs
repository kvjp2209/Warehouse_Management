using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Web_Client.Data.RequestDTO;
using Web_Client.Data;
using Web_Client.Data.ResponseDTO;
using Web_Client.Services;

namespace Web_Client.Controllers
{
    public class SupplierController : Controller
    {
        public SupplierController()
        {

        }

        public async Task<IActionResult> Index()
        {
            var client = new ClientService(HttpContext);
            var response = await client.Get<List<SupplierResponseDTO>>("http://localhost:5299/api/supplier");
            ViewData.Add("Abc", "data");
            return View(response);
        }

        //add new supplier
        [HttpGet]
        public async Task<IActionResult> Add([FromQuery] bool? success = null)
        {
            var client = new ClientService(HttpContext);
            ViewData["success"] = success;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> OnPostAdd(SupplierRequestDTO p)
        {
            var client = new ClientService(HttpContext);
            var res = await client.Post<ApiResponse>("http://localhost:5299/api/supplier", p);
            if (res?.IsSuccess == true)
            {
                return RedirectToAction("Add", "Supplier",
                    new { Success = true });
            }
            else
            {
                return RedirectToAction("Add", "Supplier",
                    new { Success = false });
            }
        }
    }
}
