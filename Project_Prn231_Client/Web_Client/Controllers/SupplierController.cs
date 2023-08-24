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
    public class SupplierController : Controller
    {
        private string rootApiUrl;
        private IConfiguration _configuration;

        public SupplierController(IConfiguration configuration)
        {
            _configuration = configuration;
            rootApiUrl = _configuration.GetSection("ApiUrls")["MyApi"];
        }

        //edit new supplier
        [HttpGet]
        public async Task<IActionResult> Profile()
        {
            var sessionAccount = HttpContext.Session.GetObjectFromJson<LoginResponseDTO>("sessionAccount");

            var supplier = await APIHelper.GetAsync<SupplierResponseDTO>(rootApiUrl + "Account/" + sessionAccount.UserId, sessionAccount.Token);
            return View(supplier);
        }

        [HttpPost]
        public async Task<IActionResult> Profile(long id, SupplierRequestDTO p)
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
    }
}
