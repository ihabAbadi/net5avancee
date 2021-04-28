using exampleMVCApplication.Services;
using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace exampleMVCApplication
{
    public static class Tools
    {
        public static IApplicationBuilder UseOurMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<FirstMiddleware>();
        }
    }
}
