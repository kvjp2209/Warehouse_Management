using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Web_Client.Data.RequestDTO;
using Web_Client.Data;
using Web_Client.Data.ResponseDTO;
using Web_Client.Services;

namespace Web_Client.Controllers
{
    public class EmployeeController : Controller
    {
        public EmployeeController()
        {

        }
        public async Task<IActionResult> Index()
        {
            var client = new ClientService(HttpContext);
            var response = await client.Get<List<EmployeeResponseDTO>>("http://localhost:5299/api/Employee");
            return View(response);
        }


        //add new Employee
        [HttpGet]
        public async Task<IActionResult> Add([FromQuery] bool? success = null)
        {
            var client = new ClientService(HttpContext);
            ViewData["success"] = success;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> OnPostAdd(EmployeeRequestDTO p)
        {
            var client = new ClientService(HttpContext);
            var res = await client.Post<ApiResponse>("http://localhost:5299/api/employee", p);
            if (res?.IsSuccess == true)
            {
                return RedirectToAction("Add", "Employee",
                    new { Success = true });
            }
            else
            {
                return RedirectToAction("Add", "Employee",
                    new { Success = false });
            }
        }

        //edit employee
        [HttpGet]
        public async Task<IActionResult> Edit(long id, [FromQuery] bool? success = null)
        {
            var client = new ClientService(HttpContext);
            var employee = await client.Get<EmployeeResponseDTO>($"http://localhost:5299/api/employee/{id}");
            ViewData["success"] = success;
            return View(employee);
        }

        [HttpPut]
        public async Task<IActionResult> OnPutEdit(long id, EmployeeRequestDTO p)
        {
            var client = new ClientService(HttpContext);
            var res = await client.Put<ApiResponse>($"http://localhost:5299/api/employee/{id}", p);
            if (res?.IsSuccess == true)
            {
                return RedirectToAction("Edit", "Employee",
                    new { Success = true });
            }
            else
            {
                return RedirectToAction("Edit", "Employee",
                    new { Success = false });
            }
        }

        //delete employee
        [HttpGet]
        public async Task<IActionResult> Delete(long id)
        {
            var client = new ClientService(HttpContext);
            await client.Delete<ApiResponse>($"http://localhost:5299/api/employee/{id}");

            return RedirectToAction("Index", "Employee");

        }

    }
}
