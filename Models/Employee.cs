using RRHHApi.DBModels;

namespace RRHHApi.Models
{
    public class Employee
    {
            public string? FirstName { get; set; }

            public string LastName { get; set; } = null!;

            public int DepartmentId { get; set; }
        }
}
