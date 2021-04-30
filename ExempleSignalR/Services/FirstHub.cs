using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExempleSignalR.Services
{
    public class FirstHub : Hub
    {
        public async Task SendMessage(string message, string user)
        {
            await Clients.All.SendAsync("ReceiveMessage", message ,user);
        }
    }
}
