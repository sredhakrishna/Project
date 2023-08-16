using Registration.Model;

using Microsoft.AspNetCore.Mvc;

using Microsoft.EntityFrameworkCore;

using Microsoft.IdentityModel.Tokens;
using Registration.Data;
using System.IdentityModel.Tokens.Jwt;

using System.Security.Claims;

using System.Text;
using static UserService;

namespace Registration.Controllers

{

    [Route("api/token")]

    [ApiController]

    public class TokenController : ControllerBase

    {

        public IConfiguration _configuration;

        private readonly DbContextClass _context;

        public TokenController(IConfiguration config, DbContextClass context)

        {

            _configuration = config;

            _context = context;

        }

        [HttpPost]

        
public async Task<IActionResult> Post(LoginModel _userData)
        {
            if (_userData != null && !string.IsNullOrWhiteSpace(_userData.Email) && !string.IsNullOrWhiteSpace(_userData.Password))
            {
                var user = await GetUser(_userData.Email, _userData.Password);

                if (user != null)
                {
                    var claims = new[]
                    {
                new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                new Claim("Email", user.Email),
                // Add other claims as needed (e.g., roles, user ID, etc.)
            };

                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                    var token = new JwtSecurityToken(
                        _configuration["Jwt:Issuer"],
                        _configuration["Jwt:Audience"],
                        claims,
                        expires: DateTime.UtcNow.AddMinutes(10),
                        signingCredentials: signIn
                    );

                    return Ok(new JwtSecurityTokenHandler().WriteToken(token));
                }
                else
                {
                    return BadRequest("Invalid credentials");
                }
            }
            else
            {
                return BadRequest();
            }
        }


        private async Task<User> GetUser(string email, string password)

        {

            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email && u.Password == password);

        }

    }

}