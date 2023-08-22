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


        //edit new supplier
        [HttpGet]
        public async Task<IActionResult> Edit(long id, [FromQuery] bool? success = null)
        {
            var client = new ClientService(HttpContext);
            var supplier = await client.Get<SupplierResponseDTO>($"http://localhost:5299/api/supplier/{id}");
            ViewData["success"] = success;
            return View(supplier);
        }

        [HttpPost]
        public async Task<IActionResult> OnPutEdit(long id, SupplierRequestDTO p)
        {
            var client = new ClientService(HttpContext);
            var res = await client.Put<ApiResponse>($"http://localhost:5299/api/supplier/{id}", p);
            if (res?.IsSuccess == true)
            {
                return RedirectToAction("Edit", "Supplier",
                    new { Success = true });
            }
            else
            {
                return RedirectToAction("Edit", "Supplier",
                    new { Success = false });
            }
        }

        //delete supplier
        [HttpGet]
        public async Task<IActionResult> Delete(long id)
        {
            var client = new ClientService(HttpContext);
            await client.Delete<ApiResponse>($"http://localhost:5299/api/supplier/{id}");

            return RedirectToAction("Index", "Supplier");

        }
    }
}
