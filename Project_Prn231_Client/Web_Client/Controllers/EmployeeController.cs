using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Web_Client.Data.RequestDTO;
using Web_Client.Data;
using Web_Client.Data.ResponseDTO;
using Web_Client.Services;
using Web_Client.Helpers;

namespace Web_Client.Controllers
{
    public class EmployeeController : BaseController
    {
        private string rootApiUrl;
        private IConfiguration _configuration;

        public EmployeeController(IConfiguration configuration)
        {
            _configuration = configuration;
            rootApiUrl = _configuration.GetSection("ApiUrls")["MyApi"];
        }

        //edit employee
        public async Task<IActionResult> Profile(long id, [FromQuery] bool? success = null)
        {
            var sessionAccount = HttpContext.Session.GetObjectFromJson<LoginResponseDTO>("sessionAccount");

            var employee = await APIHelper.GetAsync<EmployeeResponseDTO>(rootApiUrl + "Employee/Account/" + sessionAccount.AccountId, sessionAccount.Token);
            return View(employee);
        }

        [HttpPost]
        public async Task<IActionResult> Profile(long id, EmployeeRequestDTO p)
        {
            var client = new ClientService(HttpContext);
            var res = await client.Put<ApiResponse>($"http://localhost:5299/api/employee/{p.EmployeeId}", p);
            BuildTempDataMessage(res);
            return RedirectToAction("Profile");
        }

        public async Task<IActionResult> OrderManagement()
        {
            var client = new ClientService(HttpContext);
            var response = await client.Get<List<OrderResponseDTO>>("http://localhost:5299/api/order");
            return View(response);
        }

        public async Task<IActionResult> ProductManagement()
        {
            var client = new ClientService(HttpContext);
            var response = await client.Get<List<ProductResponseDTO>>("http://localhost:5299/api/product");
            return View(response);
        }


        //add new product
        public async Task<IActionResult> CreateProduct([FromQuery] bool? success = null)
        {
            var client = new ClientService(HttpContext);
            var listWarehouse = await client.Get<List<WarehouseResponseDTO>>("http://localhost:5299/api/warehouse");
            ViewData["success"] = success;
            return View(listWarehouse);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(ProductRequestDTO p)
        {
            var client = new ClientService(HttpContext);
            var res = await client.Post<ApiResponse>("http://localhost:5299/api/product", p);
            BuildTempDataMessage(res);
            return RedirectToAction("CreateProduct");
        }

        //edit new product
        public async Task<IActionResult> UpdateProduct(long id, [FromQuery] bool? success = null)
        {
            var client = new ClientService(HttpContext);
            var product = await client.Get<ProductResponseDTO>($"http://localhost:5299/api/product/{id}");
            var listWarehouse = await client.Get<List<WarehouseResponseDTO>>("http://localhost:5299/api/warehouse");
            ViewData["success"] = success;
            ViewData["listWarehouse"] = listWarehouse;
            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateProduct(ProductRequestDTO p)
        {
            var client = new ClientService(HttpContext);
            var res = await client.Put<ApiResponse>($"http://localhost:5299/api/product/{p.ProductId}", p);
            BuildTempDataMessage(res);
            return RedirectToAction("UpdateProduct", new {id = p.ProductId});
        }

        //delete product
        public async Task<IActionResult> DeleteProduct(long id)
        {
            var client = new ClientService(HttpContext);
            await client.Delete<ApiResponse>($"http://localhost:5299/api/product/{id}");

            return RedirectToAction("ProductManagement");
        }

        public async Task<IActionResult> WarehouseManagement()
        {
            var client = new ClientService(HttpContext);
            var response = await client.Get<List<WarehouseResponseDTO>>("http://localhost:5299/api/warehouse");
            ViewData.Add("Abc", "data");
            return View(response);
        }

        //add new warehouse
        public async Task<IActionResult> CreateWarehouse([FromQuery] bool? success = null)
        {
            var client = new ClientService(HttpContext);
            ViewData["success"] = success;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateWarehouse(WarehouseRequestDTO p)
        {
            var client = new ClientService(HttpContext);
            var res = await client.Post<ApiResponse>("http://localhost:5299/api/warehouse", p);
            BuildTempDataMessage(res);
            return RedirectToAction("CreateWarehouse");
        }

        //edit new warehouse
        public async Task<IActionResult> UpdateWarehouse(long id, [FromQuery] bool? success = null)
        {
            var client = new ClientService(HttpContext);
            var warehouse = await client.Get<WarehouseResponseDTO>($"http://localhost:5299/api/warehouse/{id}");
            ViewData["success"] = success;
            return View(warehouse);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateWarehouse(WarehouseRequestDTO p)
        {
            var client = new ClientService(HttpContext);
            var res = await client.Put<ApiResponse>($"http://localhost:5299/api/warehouse/{p.WarehouseId}", p);
            BuildTempDataMessage(res);
            return RedirectToAction("UpdateWarehouse", new { id = p.WarehouseId });
        }

        //delete warehouse
        public async Task<IActionResult> DeleteWarehouse(long id)
        {
            var client = new ClientService(HttpContext);
            await client.Delete<ApiResponse>($"http://localhost:5299/api/warehouse/{id}");

            return RedirectToAction("WarehouseManagement");

        }
    }
}
