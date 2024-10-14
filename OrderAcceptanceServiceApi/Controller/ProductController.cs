using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderAcceptanceServiceApi.Model;
using OrderAcceptanceServiceApi.Repository;

namespace OrderAcceptanceServiceApi.Controller
{
    // ProductController - контроллер для работы с товарами
    [Route("api/products")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        // получить все товары
        [HttpGet]
        public async Task<List<Product>> ListAll()
        {
            return await _productRepository.GetAllAsync();
        }
        // добавить новый товар
        [HttpPost]
        public async Task Add(Product product)
        {
            await _productRepository.AddAsync(product);
            // установить статус-код ответа
            HttpContext.Response.StatusCode = StatusCodes.Status204NoContent;
        }
        // получить товар по id
        [HttpGet("{id:int}")]
        public async Task<Product> GetProduct(int id)
        {
            return await _productRepository.GetAsync(id);
        }
        // получить товар по названию
        [HttpGet("product")]
        public async Task<Product> GetByName(string name)
        {
            return await _productRepository.GetByNameAsync(name);
        }
        // удалить товар
        [HttpDelete("{id:int}")]
        public async Task<Product> Remove(int id)
        {
            return await _productRepository.RemoveAsync(id);
        }
        // изменить данные о товаре
        [HttpPatch("{id:int}")]
        public async Task<Product> Update(int id, Product product)
        {
            return await _productRepository.UpdateAsync(id, product);
        }
    }
}
