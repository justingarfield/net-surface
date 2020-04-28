using System.Threading.Tasks;

namespace NetSurface.AspNetCore.Host.Abstractions
{
    //
    // Summary:
    //     Defines methods for objects that are able to provision resources.
    public interface IProvisioningProvider {
        Task<bool> CanCommunicateWithProvider();
    }
}
