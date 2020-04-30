using System.Threading.Tasks;

namespace NetSurface.AspNetCore.SignalR.Abstractions
{
    public interface IProvisioningHub {
        Task ToggleUserProviders(string[] providerNames);
        Task ToggleUserCapabilities(string[] capabilityNames);
    }
}
