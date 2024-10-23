using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Address
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
