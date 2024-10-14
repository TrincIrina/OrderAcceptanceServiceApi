using OrderAcceptanceServiceApi.Model;

namespace OrderAcceptanceServiceApi.Repository
{
    public interface IProductInOrderRepository
    {
        // добавление нового заказа
        Task AddAsync(ProductInOrder po);

        // получить список заказов
        Task<List<ProductInOrder>> GetAllAsync();

        // получение заказа по id
        Task<ProductInOrder> GetAsync(int id);

        // удаление заказа
        Task RemoveAsync(int id);        
    }
}
