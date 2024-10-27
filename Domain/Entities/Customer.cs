using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Customer
    {

        public string CustomerId { get; set; }        
        public int ShoppingCartId { get; set; }
        public ShoppingCart ShoppingCart { get; set; }
        public ICollection<Order> Orders { get; set; } = new List<Order>();
        public ICollection<CreditCardInfo> CreditCards { get; set; } = new List<CreditCardInfo>();
    }
}
