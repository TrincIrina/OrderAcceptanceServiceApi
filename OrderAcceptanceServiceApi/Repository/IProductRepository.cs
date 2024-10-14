using OrderAcceptanceServiceApi.Model;

namespace OrderAcceptanceServiceApi.Repository
{
    public interface IProductRepository
    {
        // поиск товара по id
        Task<Product> GetAsync(int id);

        // поиск товара по названию
        Task<Product> GetByNameAsync(string name);

        // получение всех товаров
        Task<List<Product>> GetAllAsync();

        // добавление товара
        Task AddAsync(Product product);

        // удаление товара
        Task<Product> RemoveAsync(int id);

        // обновление товара
        Task<Product> UpdateAsync(int id, Product product);
    }
}
