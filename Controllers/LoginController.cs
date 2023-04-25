using HRMS.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly HRMSDbContext _context;

        public LoginController(IConfiguration configuration,HRMSDbContext context)
        {
            _configuration = configuration;
            _context = context;
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult Login([FromBody] UserLogin userLogin)
        {
            var user = GetUser(userLogin);
            if(user != null)
            {
                ResponseModel<string> response = new ResponseModel<string>();

                var token = GenerateToken(user);
                response.Token = token;
                response.Status = true;
                return Ok(response);
            }
            return NotFound("User not found");
        }

        private string GenerateToken(Users user)
        {
            var securitykey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securitykey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier,user.UserName),
                new Claim(ClaimTypes.Email,user.Email),
                new Claim(ClaimTypes.Role,user.roles.RoleName)
             };

            var token = new JwtSecurityToken(_configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"], claims, expires: DateTime.Now.AddMinutes(30), signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }


        private Users GetUser(UserLogin userLogin)
        {
            var user = _context.Users.Include(x => x.roles).FirstOrDefault(x => x.UserName.ToLower() == 
            userLogin.UserName.ToLower() && x.Password.ToLower() == userLogin.Password.ToLower());

            if(user != null)
            {
                return user;
            }
            return null;
        }
    }
}
