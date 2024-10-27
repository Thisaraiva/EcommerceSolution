using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Employee
    {
        public string EmployeeId { get; set; }        
        public int PositionId { get; set; }
        public Position Position { get; set; }
        public DateTime HireDate { get; set; } = DateTime.UtcNow;           

    }

}
