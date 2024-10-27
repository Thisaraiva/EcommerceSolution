using Domain.Entities;
using Infrastructure.Identity;
using System.ComponentModel.DataAnnotations;

namespace Application.DTOs
{
    public class CustomerDTO
    {        
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string ApplicationUserId { get; set; }
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
        public ICollection<AddressDTO> Addresses { get; set; }
        public int ShoppingCartId { get; set; }
        public ShoppingCart ShoppingCart { get; set; }
        public ICollection<Order> Orders { get; set; }
        public ICollection<CreditCardInfo> CreditCards { get; set; }

        public void AddAddressDTO(AddressDTO address)
        {
            Addresses.Add(address);
        }
    }
}
