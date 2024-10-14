using System.Text.Json.Serialization;

namespace OrderAcceptanceServiceApi.Model
{
    // Product - объект товара, который можно заказать на нашем сайте
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public bool IsAvailability { get; set; }

        [JsonIgnore]
        public HashSet<ProductInOrder>? Orders { get; set; }

        public Product() { }
    }
}
