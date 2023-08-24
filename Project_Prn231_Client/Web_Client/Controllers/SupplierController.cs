using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Web_Client.Data.RequestDTO;
using Web_Client.Data;
using Web_Client.Data.ResponseDTO;
using Web_Client.Services;
using Web_Client.Helpers;
using Microsoft.AspNetCore.Http.Extensions;

namespace Web_Client.Controllers
{
    public class SupplierController : BaseController
    {
        private string rootApiUrl;
        private IConfiguration _configuration;

        public SupplierController(IConfiguration configuration)
        {
            _configuration = configuration;
            rootApiUrl = _configuration.GetSection("ApiUrls")["MyApi"];
        }

        //edit new supplier
        public async Task<IActionResult> Profile()
        {
            var sessionAccount = HttpContext.Session.GetObjectFromJson<LoginResponseDTO>("sessionAccount");

            var supplier = await APIHelper.GetAsync<SupplierResponseDTO>(rootApiUrl + "Supplier/Account/" + sessionAccount.AccountId, sessionAccount.Token);
            return View(supplier);
        }

        [HttpPost]
        public async Task<IActionResult> Profile(SupplierRequestDTO p)
        {
            var client = new ClientService(HttpContext);
            var res = await client.Put<ApiResponse>($"http://localhost:5299/api/supplier/{p.SupplierId}", p);
            BuildTempDataMessage(res);
            return RedirectToAction("Profile");
        }

        public async Task<IActionResult> BatchManagement()
        {
            var sessionAccount = HttpContext.Session.GetObjectFromJson<LoginResponseDTO>("sessionAccount");

            var response = await APIHelper.GetAsync<List<BatchResponseDTO>>("http://localhost:5299/api/Batch/Supplier/" + sessionAccount.UserId, sessionAccount.Token);
            //var client = new ClientService(HttpContext);
            //var response = await client.Get<List<BatchResponseDTO>>("http://localhost:5299/api/Batch");
            return View(response);
        }

        public async Task<IActionResult> CreateBatch()
        {
            var sessionAccount = HttpContext.Session.GetObjectFromJson<LoginResponseDTO>("sessionAccount");
            ViewBag.Product = await APIHelper.GetAsync<List<ProductResponseDTO>>(rootApiUrl + $"Product", sessionAccount.Token);

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateBatch(BatchRequestDTO p)
        {
            var sessionAccount = HttpContext.Session.GetObjectFromJson<LoginResponseDTO>("sessionAccount");

            p.SupplierId = (long)sessionAccount.UserId;
            p.WarehouseId = 1;
            var res = await APIHelper.PostAsync<BatchRequestDTO, ApiResponse>(rootApiUrl + "Batch", p, sessionAccount.Token);
            BuildTempDataMessage(res);
            return RedirectToAction("BatchManagement");
        }
    }
}
