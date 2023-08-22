using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web_Api.Data.RequestDTO;
using Web_Api.Services.Interfaces;

namespace Web_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            try
            {
                var response = await _productService.GetAllProducts();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(long id)
        {
            try
            {
                var response = await _productService.GetProductById(id);
                return Ok(response);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(ProductRequestDTO productRequestDTO)
        {
            try
            {
                var response = await _productService.CreateProduct(productRequestDTO);
                return Ok(response);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(long id, ProductRequestDTO productRequestDTO)
        {
            try
            {
                var response = await _productService.UpdateProduct(id, productRequestDTO);
                return Ok(response);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(long id)
        {
            try
            {
                var response = await _productService.DeleteProduct(id);
                return Ok(response);
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
