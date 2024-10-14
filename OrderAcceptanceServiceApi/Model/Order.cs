using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace OrderAcceptanceServiceApi.Model
{
    // Order - класс, описывающий заявку на покупку товара
    [Microsoft.EntityFrameworkCore.Index(nameof(Code), IsUnique = true)]
    public class Order
    {
        public int Id { get; set; }
        public string Code { get; set; } = string.Empty;
        public string NameClient { get; set; } = string.Empty;
        public DateTime Date { get; set; } = new DateTime();
        public string ListProducts { get; set; } = string.Empty;

        [JsonIgnore]
        public HashSet<ProductInOrder>? Products { get; set; }

        public Order() { }
    }
}
