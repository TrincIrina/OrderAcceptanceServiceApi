using Microsoft.EntityFrameworkCore;
using OrderAcceptanceServiceApi.Model;

namespace OrderAcceptanceServiceApi.Repository
{
    public class OrderRepository : IOrderRepository
    {
        // менеджер для работы с БД
        private readonly ApplicationDbContext _db;

        public OrderRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        // добавление нового заказа
        public async Task AddAsync(Order order)
        {
            await _db.Orders.AddAsync(order);
            await _db.SaveChangesAsync();
        }
        // получение всех заказов
        public async Task<List<Order>> GetAllAsync()
        {
            return await _db.Orders.ToListAsync();
        }
        // получение заказа по id
        public async Task<Order> GetAsync(int id)
        {
            return await _db.Orders.FirstOrDefaultAsync(o => o.Id == id);
        }
        // удаление заказа
        public async Task RemoveAsync(int id)
        {
            Order? order = await _db.Orders.FirstOrDefaultAsync(o => o.Id == id);
            if (order != null)
            {
                _db.Orders.Remove(order);
                await _db.SaveChangesAsync();
            }
        }
    }
}
