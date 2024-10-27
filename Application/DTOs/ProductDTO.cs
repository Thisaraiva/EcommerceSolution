using System.ComponentModel.DataAnnotations.Schema;

namespace Application.DTOs
{
    public class ProductDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }
        public string URLImage { get; set; }
    }
}
