using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class CreditCardInfo
    {
        [Key]
        public int CredtCardId { get; set; }

        [Required]
        public string? CardNumber { get; set; }

        [Required]
        public string? CardHolderName { get; set; }

        [Required, DataType(DataType.Date)]
        public DateTime ExpiryDate { get; set; }

        [Required]
        public string? CVV { get; set; }

        public string CustomerId { get; set; }
        public Customer Customer { get; set; } 
    }
}
