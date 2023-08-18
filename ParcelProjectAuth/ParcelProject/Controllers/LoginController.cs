using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using ParcelProject.Data;
using ParcelProject.Model;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ParcelProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {

        IConfiguration configuration;
        DbContextClass database;
        AdminUser ad = new AdminUser();


        public LoginController(IConfiguration ic, DbContextClass database)
        {

            configuration = ic;
            this.database = database;

        }
        [HttpPost]
        public ActionResult Login([FromBody] Login lg)
        {
            if (lg != null)
            {

                var user = GetUser(lg.email, lg.password);


                if (user != null)
                {
                    var claim = new[]
              {
                        new Claim("FirstName" , user.First_Name ),
                        new Claim("LastName" , user.Last_Name ),
                        new Claim("PhoneNo" , user.PhoneNo ),
                         new Claim("User-email" , user.Email),
                          //new Claim(ClaimTypes.Role,user.Role),
                    };

                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));
                    var Signincerdincial = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    var token = new JwtSecurityToken(

                       configuration["Jwt:Issuer"],
                       configuration["Jwt:Audience"],
                       claim,
                       expires: DateTime.UtcNow.AddMinutes(10),
                       signingCredentials: Signincerdincial
                       );
                    return Ok(new JwtSecurityTokenHandler().WriteToken(token));

                }
                else
                {
                    return BadRequest("No user");
                }

            }
            else
            {
                return BadRequest("No input");
            }

        }

        private AdminUser GetUser(string email, string password)
        {
            return database.ADMIN_USER.FirstOrDefault(opton => opton.Email == email && opton.Password == password);
        }
    }
}
