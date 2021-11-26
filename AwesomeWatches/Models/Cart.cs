namespace AwesomeWatches.Models;

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
        var cartItem = CartItems
            .FirstOrDefault(i =>
            i.Item.Id == newCartItem.Item.Id);

        if (cartItem != null)
        {
            cartItem.Quantity++;
        }
        else
        {
            CartItems.Add(newCartItem);
        }
    }
}

