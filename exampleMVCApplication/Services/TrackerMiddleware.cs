using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace exampleMVCApplication.Services
{
    public class TrackerMiddleware
    {
        private RequestDelegate _next;

        public TrackerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext context)
        {
            var userAgent= context.Request.Headers["user-agent"];
            var ip = context.Connection.RemoteIpAddress;
            var serverName = context.Request.Host;
            Debug.WriteLine(userAgent);
            Debug.WriteLine(ip);
            Debug.WriteLine(serverName);
            return _next.Invoke(context);
        }
    }
}
