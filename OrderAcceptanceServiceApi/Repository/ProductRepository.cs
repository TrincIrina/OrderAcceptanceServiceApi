using Microsoft.EntityFrameworkCore;
using OrderAcceptanceServiceApi.Model;

namespace OrderAcceptanceServiceApi.Repository
{
    public class ProductRepository : IProductRepository
    {
        // менеджер для работы с БД
        private readonly ApplicationDbContext _db;

        public ProductRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        // добавление нового продукта
        public async Task AddAsync(Product product)
        {
            // проверка стоимости товара
            if (product.Price < 0)
            {
                throw new ArgumentException("product price must be greater or equal then 0");
            }
            // проверка наличия данного продукта
            Product? check = await GetByNameAsync(product.Name);
            if (check != null)
            {
                throw new ArgumentException("there is already a product with this name");
            }
            await _db.Products.AddAsync(product);
            await _db.SaveChangesAsync();
        }
        // получение всех продуктов
        public async Task<List<Product>> GetAllAsync()
        {
            return await _db.Products.ToListAsync();
        }
        // получение продукта по id
        public async Task<Product> GetAsync(int id)
        {
            return await _db.Products.FirstOrDefaultAsync(p => p.Id == id);
        }
        // получение продукта по имени
        public async Task<Product> GetByNameAsync(string name)
        {
            return await _db.Products.FirstOrDefaultAsync(p => p.Name == name);
        }
        // удаление продукта
        public async Task<Product> RemoveAsync(int id)
        {
            Product? product = await _db.Products.FirstOrDefaultAsync(p => p.Id == id);
            if (product != null)
            {
                _db.Products.Remove(product);
                await _db.SaveChangesAsync();
            }
            return product;
        }
        // обновление продукта
        public async Task<Product> UpdateAsync(int id, Product product)
        {
            Product? updeted = await _db.Products.FirstOrDefaultAsync(p => p.Id == id);
            if (updeted != null)
            {
                // проверка стоимости товара
                if (product.Price < 0)
                {
                    throw new ArgumentException("product price must be greater or equal then 0");
                }
                updeted.Name = product.Name;
                updeted.Price = product.Price;
                updeted.IsAvailability = product.IsAvailability;
                await _db.SaveChangesAsync();
            }
            return updeted;
        }        
    }
}
