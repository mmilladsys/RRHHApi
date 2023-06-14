using Microsoft.AspNetCore.Mvc;
using RRHHApi.DBModels;
using RRHHApi.Models;

namespace RRHHApi.Controllers
{
    [Route("[controller]")]
    [ControllerName("Department")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        public class Grouped
        {
            public int Id { get; set; }
            public List<Employee>? EmployeeL { get; set; }
        }
        private readonly DBConnection _db = new DBConnection();

        [HttpGet(Name = "GetDepartments")]
        public async Task<ActionResult> GetDepartments()
        {
            var DeparmentEmployees = _db.T_EMPLOYEES.Select(j => new Employee
            {
                DepartmentId = j.DEPARTMENT_ID ?? 0,
                FirstName = j.FIRST_NAME,
                LastName = j.LAST_NAME
            }).GroupBy(k => k.DepartmentId).Select(s => new Grouped { Id = s.Key, EmployeeL = s.ToList() })
           .ToDictionary(k => k.Id);

            var Departments = _db.T_DEPARTMENTS.Select(s => new Departament
            {
                Id = s.DEPARTMENT_ID,
                Name = s.DEPARTMENT_NAME,
                IdManager = s.MANAGER_ID,
                EmployeeList = DeparmentEmployees.ContainsKey(s.DEPARTMENT_ID) ? DeparmentEmployees[s.DEPARTMENT_ID].EmployeeL : null
            }).ToList();
            return Ok(Departments);
        }

        [HttpPost(Name = "PostDepartment")]

        public dynamic DepPost(string nameP, int managerP, int locationP) 
        {
            try
            {
                T_DEPARTMENTS Departamento = new T_DEPARTMENTS
                {
                    DEPARTMENT_NAME = nameP,
                    MANAGER_ID = managerP,
                    LOCATION_ID = locationP
                };
                _db.T_DEPARTMENTS.Add(Departamento);
                _db.SaveChanges();
                return Ok();
            } catch (Exception e) {
                return e;
            }
        }

    }
}
