using Microsoft.AspNetCore.Mvc;
using OrderAcceptanceServiceApi.Model;
using OrderAcceptanceServiceApi.Repository;

namespace OrderAcceptanceServiceApi.Controller
{
    // ProductInOrderController - контроллер для работы с заказами
    [Route("api/product-orders")]
    [ApiController]
    public class ProductInOrderController : ControllerBase
    {        
        private readonly IProductInOrderRepository _productInOrderRepository;

        public ProductInOrderController(            
            IProductInOrderRepository productInOrderRepository)
        {           
            _productInOrderRepository = productInOrderRepository;
        }
        
        [HttpGet]
        public async Task<List<ProductInOrder>> GetAll()
        {
            return await _productInOrderRepository.GetAllAsync();
        }

        [HttpPost]
        public async Task Add(ProductInOrder productInOrder)
        {
            await _productInOrderRepository.AddAsync(productInOrder);
            // установить статус-код ответа
            HttpContext.Response.StatusCode = StatusCodes.Status204NoContent;
        }

        [HttpGet("{id:int}")]
        public async Task<ProductInOrder> GetProductInOrder(int id)
        {
            return await _productInOrderRepository.GetAsync(id);
        }

        [HttpDelete("{id:int}")]
        public async Task Remove(int id)
        {
            await _productInOrderRepository.RemoveAsync(id);
            // установить статус-код ответа
            HttpContext.Response.StatusCode = StatusCodes.Status204NoContent;
        }
    }
}
