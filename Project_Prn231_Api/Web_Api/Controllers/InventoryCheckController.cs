using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web_Api.Data.RequestDTO;
using Web_Api.Services.Interfaces;

namespace Web_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryCheckController : ControllerBase
    {
        private readonly IInventoryCheckService _inventoryCheckService;

        public InventoryCheckController(IInventoryCheckService inventoryCheckService)
        {
            _inventoryCheckService = inventoryCheckService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllInventoryChecks()
        {
            try
            {
                var response = await _inventoryCheckService.GetAllInventoryChecks();
                return Ok(response);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetInventoryCheckById(long id)
        {
            try
            {
                var response = await _inventoryCheckService.GetInventoryCheckById(id);
                return Ok(response);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateInventoryCheck(InventoryCheckRequestDTO inventoryCheckRequestDTO)
        {
            try
            {
                var response = await _inventoryCheckService.CreateInventoryCheck(inventoryCheckRequestDTO);
                return Ok(response);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateInventoryCheck(long id, InventoryCheckRequestDTO inventoryCheckRequestDTO)
        {
            try
            {
                var response = await _inventoryCheckService.UpdateInventoryCheck(id, inventoryCheckRequestDTO);
                return Ok(response);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInventoryCheck(long id)
        {
            try
            {
                var response = await _inventoryCheckService.DeleteInventoryCheck(id);
                return Ok(response);
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
