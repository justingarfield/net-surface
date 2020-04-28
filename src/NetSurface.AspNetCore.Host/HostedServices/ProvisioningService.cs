using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Hosting;
using System;

namespace NetSurface.AspNetCore.Host.HostedServices
{
    public partial class ProvisioningService : IHostedService {

        private readonly ILogger<ProvisioningService> _logger = null;

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            // Loop is here to wait until the server is running
            while (true)
            {
                try
                {
                    _logger.LogInformation("StartAsync called.");
                    break;
                }
                catch (Exception ex)
                {
                    _logger.LogError($"0hs n0s! {ex.Message}");
                    await Task.Delay(1000);
                }
            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("StopAsync called.");
            return Task.Delay(1000);
        }
    }
}
