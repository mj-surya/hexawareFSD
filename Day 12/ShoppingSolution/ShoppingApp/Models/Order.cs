using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShoppingApp.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public string CartId { get; set; }
        [ForeignKey("cartNumber")]
        public Cart Cart { get; set; }
        public string Date { get; set; }
    }
}
