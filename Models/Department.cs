namespace RRHHApi.Models
{
    public class Departament
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public int? IdManager { get; set; }

        public List<Employee>? EmployeeList { get; set; }
    }

    public class DepartmentPost
    {
        public string Name { get; set; } = null!;

        public int? IdManager { get; set; }

        public int? LocationId { get; set; }
    }
}
