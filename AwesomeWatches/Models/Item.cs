using System.ComponentModel.DataAnnotations.Schema;

namespace AwesomeWatches.Models
{
    public class Item
    {
        public int Id { get; set; }
        public Product Product { get; set; }
        [Column(TypeName = "money")]
        public decimal Price { get; set; }
        public int QuantityInStock { get; set; }

    }
}
