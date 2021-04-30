using AuthenticationExemple.Models;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthenticationExemple.Tools
{
    public class RoleRequirement : IAuthorizationRequirement
    {
        private string role;

        public string Role { get => role; set => role = value; }
    }
}
