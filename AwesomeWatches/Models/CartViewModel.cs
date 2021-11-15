namespace AwesomeWatches.Models
{
    public class CartViewModel
    {
        public CartViewModel()
        {
            CartItems = new HashSet<CartItem>();
        }
        public ICollection<CartItem> CartItems { get; set; }
        public decimal OrderTotal { get; set; }
    }
}
