using AuthenticationExemple.Interfaces;
using AuthenticationExemple.Models;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AuthenticationExemple.Tools
{
    public class JwtService : ITokenGenerator
    {
        public string MakeToken(CustomUSer user)
        {
            SigningCredentials signingCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Hello world from our api token")), SecurityAlgorithms.HmacSha256);
            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Role.ToString())
            };
            JwtSecurityToken jwt = new JwtSecurityToken(issuer:"utopios",claims:claims, signingCredentials:signingCredentials, expires:DateTime.Now.AddMinutes(2));
            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }
    }
}
