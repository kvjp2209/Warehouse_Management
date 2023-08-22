using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;
using Web_Api.Data;
using Web_Api.Data.RequestDTO;
using Web_Api.Models;
using Web_Api.Services.Interfaces;

namespace Web_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WarehouseController : ControllerBase
    {
        private readonly IWarehouseService _warehouseService;

        public WarehouseController(IWarehouseService warehouseService)
        {
            _warehouseService = warehouseService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllWarehouses()
        {
            try
            {
                var response = await _warehouseService.GetAllWarehouses();
                return Ok(response);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetWarehouseById(long id)
        {
            try
            {
                var response = await _warehouseService.GetWarehouseById(id);
                return Ok(response);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateWarehouse(WarehouseRequestDTO warehouseRequestDTO)
        {
            try
            {
                var response = await _warehouseService.CreateWarehouse(warehouseRequestDTO);
                return Ok(response);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateWarehouse(long id, WarehouseRequestDTO warehouseRequestDTO)
        {
            try
            {
                var response = await _warehouseService.UpdateWarehouse(id, warehouseRequestDTO);
                return Ok(response);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWarehouse(long id)
        {
            try
            {
                var response = await _warehouseService.DeleteWarehouse(id);
                return Ok(response);
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
