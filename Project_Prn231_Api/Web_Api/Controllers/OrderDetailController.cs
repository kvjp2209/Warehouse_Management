using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web_Api.Data.RequestDTO;
using Web_Api.Service.Interfaces;

namespace Web_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailController : ControllerBase
    {
        private readonly IOrderDetailService _orderDetailService;

        public OrderDetailController(IOrderDetailService orderDetailService)
        {
            _orderDetailService = orderDetailService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOrderDetails()
        {
            try
            {
                var response = await _orderDetailService.GetAllOrderDetails();
                return Ok(response);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderDetailById(long id)
        {
            try
            {
                var response = await _orderDetailService.GetOrderDetailById(id);
                return Ok(response);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrderDetail(OrderDetailRequestDTO orderDetailRequestDTO)
        {
            try
            {
                var response = await _orderDetailService.CreateOrderDetail(orderDetailRequestDTO);
                return Ok(response);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrderDetail(long id, OrderDetailRequestDTO orderDetailRequestDTO)
        {
            try
            {
                var response = await _orderDetailService.UpdateOrderDetail(id, orderDetailRequestDTO);
                return Ok(response);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrderDetail(long id)
        {
            try
            {
                var response = await _orderDetailService.DeleteOrderDetail(id);
                return Ok(response);
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
