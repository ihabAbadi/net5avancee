using AuthenticationExemple.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthenticationExemple.Interfaces
{
    public interface ITokenGenerator
    {
        string MakeToken(CustomUSer user);
    }
}
