using OrderAcceptanceServiceApi.Model;

namespace OrderAcceptanceServiceApi.Repository
{
    public interface IOrderRepository
    {
        // добавление нового заказа
        Task AddAsync(Order order);

        // получить список заказов
        Task<List<Order>> GetAllAsync();

        // получить заказ по id
        Task<Order> GetAsync(int id);

        // удалить заказ
        Task RemoveAsync(int id);
    }
}
