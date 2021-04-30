using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExempleSignalR.Services
{
    public class FirstHub : Hub
    {
        public async Task SendMessage(string message, string user, string group)
        {
            //await Clients.All.SendAsync("ReceiveMessage", message ,user);
            await Clients.Group(group).SendAsync("ReceiveMessage", message, user);
        }

        public async Task CreateGroup(string element)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, element);
        }
    }
}
