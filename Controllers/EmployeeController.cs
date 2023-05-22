using RRHHApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace RRHHApi.Controllers
{
    [ApiController]
    [ControllerName("Employee")]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly DBConnection _db = new DBConnection();

        [HttpGet(Name = "GetEmployees")]
        public async Task<List<Employee>> GetUsers()
        {
            //Consulta con JOIN
            var results = _db.T_EMPLOYEES.Join(_db.T_DEPARTMENTS,
                employees => employees.DEPARTMENT_ID,
                departments => departments.DEPARTMENT_ID,
                (employees, departments) => new { Employees = employees, Deparments = departments }
                ).Select(d => new Employee
                {
                    FirstName = d.Employees.FIRST_NAME,
                    LastName = d.Employees.LAST_NAME,
                    DepartmentId = (int)d.Employees.DEPARTMENT_ID,
                }
            );
            return results.ToList();
        }

        /* //Consulta sin anidación
        var empleados = _db.T_EMPLOYEES.Select(d => new Employees
            {
                employeeId = d.EMPLOYEE_ID,
                firstName = d.FIRST_NAME,
                lastName = d.LAST_NAME,
                email = d.EMAIL,
                phoneNumber = d.PHONE_NUMBER,
                hireDate = d.HIRE_DATE,
                jobId = d.JOB_ID,
                salary = d.SALARY,
                commissionPct = d.COMMISSION_PCT,
                managerId = d.MANAGER_ID,
                departmentId = d.DEPARTMENT_ID,
                departmentsName = d.DEPARTMENT.DEPARTMENT_NAME,
                department = d.T_DEPARTMENTS
            }).ToList();
            return empleados;*/

        //Consulta con SelectMany
        /*var empleados = _db.T_EMPLOYEES.SelectMany(d => d.T_DEPARTMENTS, (emp, DepartmentList) => new { emp, DepartmentList });
        var empleados2 = empleados.ToList();*/
    }
}
