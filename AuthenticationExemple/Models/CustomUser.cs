using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthenticationExemple.Models
{
    public class CustomUSer
    {
        private string email;
        private Role role;

        public string Email { get => email; set => email = value; }
        public Role Role { get => role; set => role = value; }
    }

    public enum Role
    {
        admin,
        customer
    }
}
