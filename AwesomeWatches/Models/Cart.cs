namespace AwesomeWatches.Models
{
    public class Cart
    {
        public Cart()
        {
            CartItems = new HashSet<CartItem>();
        }
        public int OrderId { get; set; }
        public ICollection<CartItem> CartItems { get; set; }
        public void AddItem(CartItem newCartItem)
        {
            if (CartItems.Any(i => i.Id == newCartItem.Item.Id))
            {
                CartItems.FirstOrDefault(i => i.Item.Id == newCartItem.Item.Id).Quantity++;
            }
            else
            {
                CartItems.Add(newCartItem);
            }
        }
    }
}
