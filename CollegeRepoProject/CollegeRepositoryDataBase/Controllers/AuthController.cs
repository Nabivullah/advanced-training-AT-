using CollegeRepositoryDataBase.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace collage_app.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly NewCollegeDbContext _context;

        public AuthController(IConfiguration configuration, NewCollegeDbContext context)
        {
            _configuration = configuration;
            _context = context;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel user)
        {
            // 🔹 Dummy user validation
            //if (user.Username == "admin" && user.Password == "admin123")
            //{
            //    var token = GenerateJwtToken(user.Username);
            //    return Ok(new { token });
            //}
            //return Unauthorized("Invalid credentials");

            if (user == null || string.IsNullOrEmpty(user.Username) || string.IsNullOrEmpty(user.Password))
                return BadRequest("Username and password are required.");

            var existingUser = await _context.Users.FirstOrDefaultAsync(u=>u.Username == user.Username && u.Password==user.Password);
            if (existingUser == null)
            {
                return Unauthorized("Invalid Username or Password");
            }

            var token=GenerateJwtToken(existingUser.Username,existingUser.Role);
            return Ok(new {
                username = existingUser.Username,
                role = existingUser.Role,
                token });
        }

        private string GenerateJwtToken(string username, string role)
        {
            var jwtSettings = _configuration.GetSection("Jwt");
            var key = Encoding.ASCII.GetBytes(jwtSettings["Key"]);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, username),
                    new Claim(ClaimTypes.Role, role) 
                }),
                Expires = DateTime.UtcNow.AddMinutes(Convert.ToDouble(jwtSettings["DurationInMinutes"])),
                Issuer = jwtSettings["Issuer"],
                Audience = jwtSettings["Audience"],
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }

    public class LoginModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
