using Microsoft.AspNetCore.Mvc;
using OrderAcceptanceServiceApi.Model;
using OrderAcceptanceServiceApi.Repository;

namespace OrderAcceptanceServiceApi.Controller
{
    // OrderController - контроллер для работы с заказами
    [Route("api/orders")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;

        public OrderController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        // получить весь список заказов
        [HttpGet]
        public async Task<List<Order>> GetAll()
        {
            return await _orderRepository.GetAllAsync();
        }
        // добавить заказ
        [HttpPost]
        public async Task Add(Order order)
        {
            await _orderRepository.AddAsync(order);
            // установить статус-код ответа
            HttpContext.Response.StatusCode = StatusCodes.Status204NoContent;
        }
        // получить заказ по id
        [HttpGet("{id:int}")]
        public async Task<Order> GetOrder(int id)
        {
            return await _orderRepository.GetAsync(id);
        }
        // удалить заказ по id
        [HttpDelete("{id:int}")]
        public async Task Remove(int id)
        {
            await _orderRepository.RemoveAsync(id);
            // установить статус-код ответа
            HttpContext.Response.StatusCode = StatusCodes.Status204NoContent;
        }
    }
}
