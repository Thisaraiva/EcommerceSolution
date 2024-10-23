using System.ComponentModel.DataAnnotations;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Identity
{
    public class ApplicationUser : IdentityUser
    {
        private string? _firstName;
        private string? _lastName;

        [Required, StringLength(50, MinimumLength = 3, ErrorMessage = "O {0} deve conter entre {2} e {1} caracteres.")]
        public string? FirstName
        {
            get => _firstName;
            set => _firstName = ToUpper(value);
        }

        [Required, StringLength(50, MinimumLength = 3, ErrorMessage = "O {0} deve conter entre {2} e {1} caracteres.")]
        public string? LastName
        {
            get => _lastName;
            set => _lastName = ToUpper(value);
        }

        public string FullName => $"{FirstName} {LastName}";

        public int? CustomerId { get; set; }  // Referência ao Customer
        public Customer? Customer { get; set; }

        public int? EmployeeId { get; set; }  // Referência ao Employee
        public Employee? Employee { get; set; }

        [Required]
        public ICollection<Address> Addresses { get; set; } = new HashSet<Address>();

        [Required, DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime RegisterDate { get; private set; } = DateTime.UtcNow;
                
        private static string? ToUpper(string? value) => value?.ToUpper();
    }
}
