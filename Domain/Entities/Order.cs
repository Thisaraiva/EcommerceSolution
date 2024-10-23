using Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public DateTime OrderDate { get; set; }
        public OrderStatus Status { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal TotalAmount { get; set; }
        public List<OrderItem>? OrderItems { get; set; }
    }

}
