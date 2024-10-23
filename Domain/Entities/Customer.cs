namespace Domain.Entities
{
    public class Customer
    {

        public int CustomerId { get; set; }
        public string ApplicationUserId { get; set; }        
        public ShoppingCart? ShoppingCart { get; set; }
        public ICollection<Order> Orders { get; set; } = new List<Order>();
        public ICollection<CreditCardInfo> CreditCards { get; set; } = new List<CreditCardInfo>();
    }
}
