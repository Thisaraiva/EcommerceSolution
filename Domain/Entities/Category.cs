using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Category
    {
        public int CategoryId { get; set; }
        //[Required]
        public string? Name { get; set; }
        public string? Description { get; set; }        
        public ICollection<Product> Products { get; set; } = new List<Product>();   
    }
}
