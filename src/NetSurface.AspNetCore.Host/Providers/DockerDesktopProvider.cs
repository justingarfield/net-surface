using System.Threading.Tasks;

namespace NetSurface.AspNetCore.Host.Abstractions
{
    //
    // Summary:
    //     Implements methods for objects that are able to provision Docker Desktop Containers.
    public class DockerDesktopProvider : IDockerDesktopProvider {

        public async Task<bool> CanCommunicateWithProvider() {
            return await Task.FromResult(false);
        }

    }
}
