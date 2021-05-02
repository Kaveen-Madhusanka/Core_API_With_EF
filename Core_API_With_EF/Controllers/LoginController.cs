using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Core_API_With_EF.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Core_API_With_EF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IConfiguration _config;
        Student1Context DbContext;
        public LoginController(IConfiguration config, Student1Context _db)
        {
            _config = config;
            DbContext = _db;
        }
        [HttpGet]
        public IActionResult Login(string userName,string Password)
        {
            Login oLoginDTO = new Login();
            oLoginDTO.UserName = userName;
            oLoginDTO.Password = Password;
            IActionResult response = Unauthorized();

            var user = AuthenticateUser(oLoginDTO);
            if (user != null)
            {
                var tokenStr = GenarateJSONWebToken(user);
                response = Ok(new { token = tokenStr });
            }
            return response;
        }

        private Login AuthenticateUser(Login oLoginDTO)
        {
            Login user = DbContext.Logins.FirstOrDefault(x => x.UserName == oLoginDTO.UserName);
            //if (oLoginDTO.UserName =="kaveen" && oLoginDTO.Password == "123")
            //{
            //    user = new Login { UserName = "kaveen", Userid = 1 };
            //}
            return user;
        }

        private string GenarateJSONWebToken(Login userInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
           {
                new Claim(JwtRegisteredClaimNames.Sub,userInfo.UserName),
                new Claim(JwtRegisteredClaimNames.NameId,userInfo.Userid.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())

            };
            var token = new JwtSecurityToken(
                    issuer: _config["Jwt:Issuer"],
                    audience: _config["Jwt:Issuer"],
                    claims,
                    expires: DateTime.Now.AddMinutes(120),
                    signingCredentials: credentials);
            var encodetoken = new JwtSecurityTokenHandler().WriteToken(token);
            return encodetoken;
        }

        [Authorize]
        [HttpPost("post")]
        public string post()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            IList<Claim> claim = identity.Claims.ToList();
            var userName = claim[0].Value;
            return "Welcome to : " + userName;
        }

        [Authorize]
        [HttpGet("GetValue")]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }
    }

}
