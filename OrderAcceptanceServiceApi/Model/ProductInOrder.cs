using System.Text.Json.Serialization;

namespace OrderAcceptanceServiceApi.Model
{
    // Product in order - объект, ссылающийся на продукт и заказ
    public class ProductInOrder
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int OrderId { get; set; }
        public int Quantity { get; set; }

        [JsonIgnore]
        public Product? Product { get; set; }
        [JsonIgnore]
        public Order? Order { get; set; }

        public ProductInOrder() { }
    }
}
