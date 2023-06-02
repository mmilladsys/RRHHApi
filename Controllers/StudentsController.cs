using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RRHHAPI.Helpers;

namespace RRHHApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
           private readonly DBConnection _db = new DBConnection();
        [HttpGet(Name = "GetCandidatos")]

        public async Task<ActionResult> GetCandidatos()
        {
            try
            {
            /* https://localhost:44355/Historia?dniAlumno=12345678 */
                HttpApiHelper helper = new HttpApiHelper();
                var endpoint = "/Historia";
                endpoint += "?dniAlumno=12345678";
                return await helper.SendAsync(HttpMethod.Get, "https://localhost:44355", endpoint, null);
            } catch(Exception e)
            {
                throw;
            }
        }

    }
}
