using System.ComponentModel.DataAnnotations.Schema;

namespace ShoppingApp.Models
{
    public class OrderDetails
    {
        public int OrderId { get; set; }
        [ForeignKey("OrderId")]
        public string ProductId { get; set; }
        public int Quantity { get; set; }
        public float Price { get; set; }
    }
}
