using RRHHApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace RRHHApi.Controllers
{
    [ApiController]
    [ControllerName("JobHistory")]
    [Route("[controller]")]
    public class HistoryController : ControllerBase
    {
        private readonly DBConnection _db = new DBConnection();


        [HttpGet(Name = "GetHistoryJobs")]

        public async Task<List<Jobs_History>> HistoryEmployees(string employeeName, DateTime dateTo)
        {
            //Consulta con métodos LINQ
            /*var resultSet = _db.T_JOB_HISTORY.Join(_db.T_EMPLOYEES,
                jobHistory => jobHistory.EMPLOYEE_ID,
                employees => employees.EMPLOYEE_ID,
                (jobHistory, employees) => new { JobHistory = jobHistory, Employees = employees }
                ).Join(_db.T_JOBS,
                jobHis => jobHis.JobHistory.JOB_ID,
                job => job.JOB_ID,
                (jobHistory, jobs) => new { JobHistory = jobHistory, Jobs = jobs })
                .Where(a => (a.JobHistory.Employees.FIRST_NAME+" "+a.JobHistory.Employees.LAST_NAME == employeeName) 
                && (a.JobHistory.JobHistory.END_DATE <= dateTo))
                .Select(j => new Jobs_History
                {
                    startDate = j.JobHistory.JobHistory.START_DATE,
                    endDate = j.JobHistory.JobHistory.END_DATE,
                    jobTitle = j.Jobs.JOB_TITLE,
                }
                );*/

            //Consulta con sintaxis SQL en LINQ
            var resultSet = from jobHistory in _db.T_JOB_HISTORY
                            join employees in _db.T_EMPLOYEES on jobHistory.EMPLOYEE_ID equals employees.EMPLOYEE_ID
                            //        join jobs in _db.T_JOBS on jobHistory.JOB_ID equals jobs.JOB_ID //Join redundante
                            where (employees.FIRST_NAME + " " + employees.LAST_NAME == employeeName) &&
                                  (jobHistory.END_DATE <= dateTo)
                            select new Jobs_History
                            {
                                startDate = jobHistory.START_DATE,
                                endDate = jobHistory.END_DATE,
                                //jobTitle = jobs.JOB_TITLE  //Join redundante
                                jobTitle = jobHistory.JOB.JOB_TITLE
                            };

            return resultSet.ToList();
        }
    }
}
