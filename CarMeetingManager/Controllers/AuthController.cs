using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using CarMeetingManager.BLL;
using CarMeetingManager.BLL.DTO;
using CarMeetingManager.DAL;
using CarMeetingManager.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace CarMeetingManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly CarMeetingContext _context;
        readonly MembersBL MembersManager;

        public AuthController(CarMeetingContext context)
        {
            _context = context;
            MembersManager = new MembersBL(context);
        }

        [HttpPost, Route("login")]
        public IActionResult Login([FromBody]MemberDTO user)
        {
            CustomPasswordHasher ph = new CustomPasswordHasher();
            if (user == null)
            {
                return BadRequest("Invalid client request");
            }

            MemberDTO DbUser = MembersManager.GetMemberByUsername(user.Username);

            if (ph.VerifyHashedPassword(DbUser.PasswordHash, user.Password, DbUser.PasswordSalt) == PasswordVerificationResult.Success)
            {
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("keycryptstring123"));
                var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

                var tokeOptions = new JwtSecurityToken(
                    issuer: "https://localhost:44398",
                    audience: "https://localhost:44398",
                    claims: new List<Claim>(),
                    expires: DateTime.Now.AddMinutes(5),
                    signingCredentials: signinCredentials
                );

                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
                return Ok(new { Token = tokenString });
            }
            else
            {
                return Unauthorized();
            }
        }
    }
}