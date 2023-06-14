using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RRHHApi.Models;
using System.Data;

namespace RRHHApi.Controllers
{
    [Route("[controller]")]
    [ControllerName("Employee")]
    [ApiController]
    public class ProgrammersController : ControllerBase
    {
        public class EmployeeProgrammer
        {
            public string? Name { get; set; }
            public string? PhoneNumber { get; set; } = null!;

        }

        private readonly DBConnection _db = new DBConnection();

        [HttpGet(Name = "GetProgammers")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "admin")]
        public dynamic Programmers()
        {
            var results = _db.T_EMPLOYEES.Where(p => p.JOB.JOB_TITLE == "Programmer").
                Select(d => new EmployeeProgrammer
                {
                    Name = d.FIRST_NAME + " " + d.LAST_NAME,
                    PhoneNumber = d.PHONE_NUMBER
                }
            );
            return results.ToList();
        }
    }
}
