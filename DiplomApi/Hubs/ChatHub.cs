using Microsoft.AspNetCore.SignalR;
using System;

namespace DiplomApi.Hubs
{
    public class ChatHub:Hub
    {
        public async Task SendMessages(string userName, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", userName, message);
        }
    }
}
