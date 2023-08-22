using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Web_Client.Data;
using Web_Client.Data.RequestDTO;
using Web_Client.Data.ResponseDTO;
using Web_Client.Services;

namespace Web_Client.Controllers
{
    public class ProductController : Controller
    {
        public ProductController()
        {

        }

        public async Task<IActionResult> Index()
        {
            var client = new ClientService(HttpContext);
            var response = await client.Get<List<ProductResponseDTO>>("http://localhost:5299/api/product");
            return View(response);
        }


        //add new product
        [HttpGet]
        public async Task<IActionResult> Add([FromQuery] bool? success = null)
        {
            var client = new ClientService(HttpContext);
            var listWarehouse = await client.Get<List<WarehouseResponseDTO>>("http://localhost:5299/api/warehouse");
            ViewData["success"] = success;
            return View(listWarehouse);
        }

        [HttpPost]
        public async Task<IActionResult> OnPostAdd(ProductRequestDTO p)
        {
            var client = new ClientService(HttpContext);
            var res = await client.Post<ApiResponse>("http://localhost:5299/api/product", p);
            if (res?.IsSuccess == true)
            {
                return RedirectToAction("Add", "Product",
                    new { Success = true });
            }
            else
            {
                return RedirectToAction("Add", "Product",
                    new { Success = false });
            }
        }
    }
}
