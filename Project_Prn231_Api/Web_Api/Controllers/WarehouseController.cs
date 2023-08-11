using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;
using Web_Api.Data;
using Web_Api.Data.RequestDTO;
using Web_Api.Models;

namespace Web_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WarehouseController : ControllerBase
    {
        private readonly Project_Prn231Context _context;

        //private readonly IWarehouseService _warehouseService;

        public WarehouseController(Project_Prn231Context context)
        {
            _context = context;
        }


        [HttpGet]
        //[Authorize(Roles = "Student,Staff")]
        public async Task<IActionResult> GetAllWarehouses()
        {
            try
            {
                var response = await _context.Warehouses.ToListAsync();
                return Ok(response);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        //[Authorize(Roles = "Student,Staff")]
        public async Task<IActionResult> GetWarehouseById(long id)
        {
            try
            {
                //var response = await _warehouseService.GetWarehouseById(id);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost]
        //[Authorize(Roles = "Staff")]
        public async Task<IActionResult> CreateWarehouse(WarehouseRequestDTO warehouseRequestDTO)
        {
            try
            {
                var data = new Warehouse
                {
                    WarehouseName = warehouseRequestDTO.WarehouseName,
                    Address = warehouseRequestDTO.Address,
                    PhoneNumber = warehouseRequestDTO.PhoneNumber
                };
                _context.Add(data);
                await _context.SaveChangesAsync();
                //var response = await _warehouseService.CreateWarehouse(warehouseRequestDTO);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        //[Authorize(Roles = "Staff")]
        public async Task<IActionResult> UpdateWarehouse(long id, WarehouseRequestDTO warehouseRequestDTO)
        {
            try
            {
                //var response = await _warehouseService.UpdateWarehouse(id, warehouseRequestDTO);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        //[Authorize(Roles = "Staff")]
        public async Task<IActionResult> DeleteWarehouse(long id)
        {
            try
            {
                //var response = await _warehouseService.DeleteWarehouse(id);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
