using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RRHHApi.DBModels;
using RRHHApi.Models;

namespace RRHHApi.Controllers
{
    [ControllerName("JobHistory")]
    [Route("[controller]")]
    [ApiController]
    public class JobHistoryController : ControllerBase
    {
        public class EmployeeFirst
        {
            public string? Name { get; set; }

            public string Mail { get; set; } = null!;

        }
        private readonly DBConnection _db = new DBConnection();

        [HttpGet(Name = "GetJobsHistory")]

        public EmployeeFirst? FirstEmployed()
        {
            return _db.T_JOB_HISTORY.OrderBy(j => j.START_DATE).Select(f => new EmployeeFirst
                {
                    Name = f.EMPLOYEE.FIRST_NAME + " " + f.EMPLOYEE.LAST_NAME,
                    Mail = f.EMPLOYEE.EMAIL  
                }).FirstOrDefault();
        }
    }
}
