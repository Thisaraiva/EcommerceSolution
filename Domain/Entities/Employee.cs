namespace Domain.Entities
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string? ApplicationUserId { get; set; }
        public string? Position { get; set; }
        public DateTime HireDate { get; set; } = DateTime.UtcNow;
    }

}
