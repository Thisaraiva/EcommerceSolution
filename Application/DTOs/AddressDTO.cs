using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class AddressDTO
    {
        public int AddressId { get; set; }

        [Required]
        public string Street { get; set; } = string.Empty;

        [Required]
        public string Number { get; set; } = string.Empty;

        public string? Complement { get; set; }

        public string Neighborhood { get; set; } = string.Empty;

        [Required]
        public string City { get; set; } = string.Empty;

        [Required]
        public string State { get; set; } = string.Empty;

        [Required]
        public string Country { get; set; } = string.Empty;

        [Required, DataType(DataType.PostalCode)]
        public string ZipCode { get; set; } = string.Empty;


        // Propriedade auxiliar para retornar o endereço completo.
        public string FullAddress => $"{Street}, {Number} - {Neighborhood}, {City} - {State}, {ZipCode}, {Country}";
    }
}
