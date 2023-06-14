using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using RRHHApi.Models;
using RRHHApi.Service;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace RRHHApi.Controllers
{
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        [HttpPost(Name = "Login")]
        //public IResult Login(UserLogin user)
        public async Task<ActionResult<UserLogin>> Login([FromBody] UserLogin user)
        {
            UserService service = new UserService();
            if (!string.IsNullOrEmpty(user.Username) && !string.IsNullOrEmpty(user.Password))
            {
                var loggedInUser = service.Get(user);
                if (loggedInUser is null) return Content("Usuario no encontrado");

                var claims = new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, loggedInUser.Username),
                    new Claim(ClaimTypes.Email, loggedInUser.Email),
                    new Claim(ClaimTypes.Role, loggedInUser.Role)
                };
                var token = new JwtSecurityToken
                    (
                    issuer: configuration.GetSection("Jwt:Issuer").Value,
                    audience: configuration.GetSection("Jwt:Audience").Value,
                    claims: claims,
                    expires: DateTime.UtcNow.AddMinutes(5),
                    notBefore: DateTime.UtcNow,
                    signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration.GetSection("Jwt:Key").Value)), SecurityAlgorithms.HmacSha256)
                    );
                var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

                return Ok(tokenString);
            } else
            {
                return Content("Faltan datos");
            }
        }

    }
}
