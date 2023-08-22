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

        //edit new product
        [HttpGet]
        public async Task<IActionResult> Edit(long id, [FromQuery] bool? success = null)
        {
            var client = new ClientService(HttpContext);
            var product = await client.Get<ProductResponseDTO>($"http://localhost:5299/api/product/{id}");
            var listWarehouse = await client.Get<List<WarehouseResponseDTO>>("http://localhost:5299/api/warehouse");
            ViewData["success"] = success;
            ViewData["listWarehouse"] = listWarehouse;
            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> OnPutEdit(long id, ProductRequestDTO p)
        {
            var client = new ClientService(HttpContext);
            var res = await client.Put<ApiResponse>($"http://localhost:5299/api/product/{id}", p);
            if (res?.IsSuccess == true)
            {
                return RedirectToAction("Edit", "Product",
                    new { Success = true });
            }
            else
            {
                return RedirectToAction("Edit", "Product",
                    new { Success = false });
            }
        }

        //delete product
        [HttpGet]
        public async Task<IActionResult> Delete(long id)
        {
            var client = new ClientService(HttpContext);
            await client.Delete<ApiResponse>($"http://localhost:5299/api/product/{id}");

            return RedirectToAction("Index", "Product");

        }
    }
}
