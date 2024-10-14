using Microsoft.EntityFrameworkCore;
using OrderAcceptanceServiceApi.Model;

namespace OrderAcceptanceServiceApi.Repository
{
    public class ProductInOrderRepository : IProductInOrderRepository
    {
        // менеджер для работы с БД
        private readonly ApplicationDbContext _db;

        public ProductInOrderRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        // добавление нового заказа
        public async Task AddAsync(ProductInOrder po)
        {
            await _db.ProductInOrders.AddAsync(po);
            await _db.SaveChangesAsync();
        }
        // получение всех заказов
        public async Task<List<ProductInOrder>> GetAllAsync()
        {
            return await _db.ProductInOrders.ToListAsync();
        }
        // получение заказа по id
        public async Task<ProductInOrder> GetAsync(int id)
        {
            return await _db.ProductInOrders.FirstOrDefaultAsync(p => p.Id == id);
        }
        // удаление заказа
        public async Task RemoveAsync(int id)
        {
            ProductInOrder? po = await GetAsync(id);
            if (po != null)
            {
                _db.ProductInOrders.Remove(po);
                await _db.SaveChangesAsync();
            }
        }
    }
}
