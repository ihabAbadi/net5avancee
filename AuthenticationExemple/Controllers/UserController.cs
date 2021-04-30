using AuthenticationExemple.Interfaces;
using AuthenticationExemple.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthenticationExemple.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        ITokenGenerator _generator;
        public UserController(ITokenGenerator generator)
        {
            _generator = generator;
        }

        [HttpPost("/api/login")]
        public IActionResult Login([FromBody] UserConnection user)
        {
            //logique métier de connexion,
            if(user.login == "ihab" && user.password == "123456")
            {
                CustomUSer customUser = new CustomUSer() { Email = "ihab@utopios.net", Role = Role.admin };
                return Ok(new { token = _generator.MakeToken(customUser) });
            }
            return NotFound();
        }
    }

    public record UserConnection(string login, string password);
}
