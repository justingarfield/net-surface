using NetSurface.AspNetCore.SignalR.Abstractions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace NetSurface.AspNetCore.SignalR.Hubs
{
    public class ProvisioningHub : Hub<IProvisioningHub>
    {
        public async Task ToggleUserProviders(string[] providerNames) {
            await Clients.All.ToggleUserProviders(providerNames);
        }

        public async Task ToggleUserCapabilities(string[] capabilityNames)
        {
            await Clients.All.ToggleUserCapabilities(capabilityNames);
        }
    }
}
