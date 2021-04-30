using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AuthenticationExemple.Tools
{
    public class RoleAuthorizationHandler : AuthorizationHandler<RoleRequirement>
    {
        //public Task HandleAsync(AuthorizationHandlerContext context)
        //{
        //    throw new NotImplementedException();
        //}
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, RoleRequirement requirement)
        {
            if(!context.User.HasClaim(c => c.Type == ClaimTypes.Email))
            {
                return Task.CompletedTask;
            }
            else
            {
                if(requirement.Role == context.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role).Value)
                {
                    context.Succeed(requirement);
                }
                return Task.CompletedTask;
            }
        }
    }
}
