using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web_Api.Data.RequestDTO;
using Web_Api.Services.Interfaces;

namespace Web_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierController : ControllerBase
    {
        private readonly ISupplierService _supplierService;

        public SupplierController(ISupplierService supplierService)
        {
            _supplierService = supplierService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSuppliers()
        {
            try
            {
                var response = await _supplierService.GetAllSuppliers();
                return Ok(response);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSupplierById(long id)
        {
            try
            {
                var response = await _supplierService.GetSupplierById(id);
                return Ok(response);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("Account/{id}")]
        public async Task<IActionResult> GetSupplierByAccountId(long id)
        {
            try
            {
                var response = await _supplierService.GetSupplierByAccountId(id);
                return Ok(response);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateSupplier(SupplierRequestDTO supplierRequestDTO)
        {
            try
            {
                var response = await _supplierService.CreateSupplier(supplierRequestDTO);
                return Ok(response);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSupplier(long id, SupplierRequestDTO supplierRequestDTO)
        {
            try
            {
                var response = await _supplierService.UpdateSupplier(id, supplierRequestDTO);
                return Ok(response);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSupplier(long id)
        {
            try
            {
                var response = await _supplierService.DeleteSupplier(id);
                return Ok(response);
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
