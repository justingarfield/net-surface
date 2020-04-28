using NetSurface.AspNetCore.SignalR.Abstractions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using System;

namespace NetSurface.AspNetCore.SignalR.Hubs
{
    public class ProvisioningHub : Hub<IProvisioningHub>
    {
        public async Task BeginPollingForDocker() {
            await Clients.All.BeginPollingForDocker();
        }

        public async Task ReceiveStatusMessage(DateTime dateTime, string message)
        {
            await Clients.All.ReceiveStatusMessage(dateTime, message);
        }
    }
}
