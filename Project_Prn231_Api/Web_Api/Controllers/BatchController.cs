using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web_Api.Data.RequestDTO;
using Web_Api.Services.Interfaces;

namespace Web_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BatchController : ControllerBase
    {
        private readonly IBatchService _batchService;

        public BatchController(IBatchService batchService)
        {
            _batchService = batchService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBatches()
        {
            try
            {
                var response = await _batchService.GetAllBatches();
                return Ok(response);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBatchById(long id)
        {
            try
            {
                var response = await _batchService.GetBatchById(id);
                return Ok(response);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateBatch(BatchRequestDTO batchRequestDTO)
        {
            try
            {
                var response = await _batchService.CreateBatch(batchRequestDTO);
                return Ok(response);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBatch(long id, BatchRequestDTO batchRequestDTO)
        {
            try
            {
                var response = await _batchService.UpdateBatch(id, batchRequestDTO);
                return Ok(response);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBatch(long id)
        {
            try
            {
                var response = await _batchService.DeleteBatch(id);
                return Ok(response);
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
