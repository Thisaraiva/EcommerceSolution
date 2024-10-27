using Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    internal class EmployeeDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public Position Position { get; set; } // Cargo do funcionário
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
        public DateTime HireDate { get; set; } = DateTime.UtcNow; // Data de contratação
        public string PhoneNumber { get; set; }
        public string CellPhone { get; set; }
        public Address Address { get; set; }
    }
}
