using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace exampleMVCApplication.Services
{
    public class FirstMiddleware
    {

        RequestDelegate _next;

        public FirstMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext httpContext)
        {
            //Logique métier de notre middleware
            Debug.WriteLine("Our special middleware");
            //throw new Exception("erreur middleware");
            return _next(httpContext);
        }
    }
}
