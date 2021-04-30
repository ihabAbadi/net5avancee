using Microsoft.AspNetCore.Authorization;
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
    
    public class ProtectedController : ControllerBase
    {
        [HttpGet("Customer")]
        [Authorize(Policy = "customer")]
        public IActionResult Customer()
        {
            return Ok(new { message = "Access customer" });
        }

        [HttpGet("Admin")]
        [Authorize(Policy = "admin")]
        public IActionResult Admin()
        {
            return Ok(new { message = "Acces admin"});
        }

        [HttpGet("Public")]
        public IActionResult Public()
        {
            return Ok(new { message = "Acces public" });
        }
    }
}
