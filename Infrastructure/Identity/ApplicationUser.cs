using System.ComponentModel.DataAnnotations;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Identity
{
    public class ApplicationUser : IdentityUser
    {
        private string? _firstName;
        private string? _lastName;
        [PersonalData]
        [Required, StringLength(50, MinimumLength = 3, ErrorMessage = "O {0} deve conter entre {2} e {1} caracteres.")]
        public string? FirstName
        {
            get => _firstName;
            set => _firstName = ToUpper(value);
        }
        [PersonalData]
        [Required, StringLength(50, MinimumLength = 3, ErrorMessage = "O {0} deve conter entre {2} e {1} caracteres.")]
        public string? LastName
        {
            get => _lastName;
            set => _lastName = ToUpper(value);
        }

        public string FullName => $"{FirstName} {LastName}";
        [PersonalData]
        public Customer? Customer { get; set; }
        [PersonalData]
        public Employee? Employee { get; set; }
        [PersonalData]
        [Required]
        public ICollection<Address> Addresses { get; set; } = new HashSet<Address>();
        [PersonalData]
        [Required, DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
        [PersonalData]
        [DataType(DataType.DateTime)]
        public DateTime RegisterDate { get; private set; } = DateTime.UtcNow;
                
        private static string? ToUpper(string? value) => value?.ToUpper();

        public void AddAddress(Address address)
        {
            Addresses.Add(address);
        }
    }
}
