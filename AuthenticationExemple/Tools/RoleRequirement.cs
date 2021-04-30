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
        private List<string> role;

        public List<string> Role { get => role; set => role = value; }

        public RoleRequirement()
        {
            Role = new List<string>();
        }
    }
}
