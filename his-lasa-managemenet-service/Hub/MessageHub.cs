using his_lasa_managemenet_service.Models;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace his_lasa_managemenet_service.Hub
{
    public class MessageHub : Microsoft.AspNetCore.SignalR.Hub
    {
        public Task SendMessage(MessageNotification messageNotification)
        {
            return Clients.All.InvokeAsync("Send", messageNotification);
        }
    }
}
