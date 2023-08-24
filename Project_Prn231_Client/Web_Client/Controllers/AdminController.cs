using Microsoft.AspNetCore.Mvc;
using Web_Client.Data.RequestDTO;
using Web_Client.Data;
using Web_Client.Data.ResponseDTO;
using Web_Client.Services;
using Web_Client.Helpers;

namespace Web_Client.Controllers
{
    public class AdminController : BaseController
    {
        private string rootApiUrl;
        private IConfiguration _configuration;

        public AdminController(IConfiguration configuration)
        {
            _configuration = configuration;
            rootApiUrl = _configuration.GetSection("ApiUrls")["MyApi"];
        }

        public async Task<IActionResult> SupplierManagementAsync()
        {
            var client = new ClientService(HttpContext);
            var response = await client.Get<List<SupplierResponseDTO>>(rootApiUrl + "supplier");
            ViewData.Add("Abc", "data");
            return View(response);
        }

        public async Task<IActionResult> CreateSupplier([FromQuery] bool? success = null)
        {
            var client = new ClientService(HttpContext);
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateSupplier(SupplierRequestDTO p)
        {
            var client = new ClientService(HttpContext);
            var res = await client.Post<ApiResponse>("http://localhost:5299/api/supplier", p);
            BuildTempDataMessage(res);
            return View();
        }

        //delete supplier
        public async Task<IActionResult> DeleteSupplier(long id)
        {
            var sessionAccount = HttpContext.Session.GetObjectFromJson<LoginResponseDTO>("sessionAccount");
            var res = await APIHelper.DeleteAsync<ApiResponse>(rootApiUrl + $"supplier/{id}", sessionAccount.Token);
            BuildTempDataMessage(res);

            return RedirectToAction("SupplierManagement");

        }

        public async Task<IActionResult> SupplierDetails(long id, [FromQuery] bool? success = null)
        {
            var client = new ClientService(HttpContext);
            var supplier = await client.Get<SupplierResponseDTO>($"http://localhost:5299/api/supplier/{id}");
            ViewData["success"] = success;
            return View(supplier);
        }

        public async Task<IActionResult> EmployeeManagement()
        {
            var client = new ClientService(HttpContext);
            var response = await client.Get<List<EmployeeResponseDTO>>("http://localhost:5299/api/Employee");
            return View(response);
        }


        public async Task<IActionResult> CreateEmployee([FromQuery] bool? success = null)
        {
            var client = new ClientService(HttpContext);
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmployee(EmployeeRequestDTO p)
        {
            var client = new ClientService(HttpContext);
            var res = await client.Post<ApiResponse>("http://localhost:5299/api/employee", p);
            BuildTempDataMessage(res);
            return View();
        }

        public async Task<IActionResult> DeleteEmployee(long id)
        {
            var sessionAccount = HttpContext.Session.GetObjectFromJson<LoginResponseDTO>("sessionAccount");
            var res = await APIHelper.DeleteAsync<ApiResponse>($"http://localhost:5299/api/employee/{id}", sessionAccount.Token);
            BuildTempDataMessage(res);
            return RedirectToAction("EmployeeManagement");

        }
    }
}
