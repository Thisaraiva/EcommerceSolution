namespace Domain.Entities
{
    public class ShoppingCart
    {
        public int ShoppingCartId { get; set; }
        public string CustomerId { get; set; }
        public Customer Customer { get; set; }

        public ICollection<ShoppingCartItem> ShoppingCartItems { get; set; } = new List<ShoppingCartItem>();
    }
}
