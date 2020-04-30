using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Hosting;
using System;

namespace NetSurface.AspNetCore.Host.HostedServices
{
    //
    // Summary:
    //     Responsible for...
    public partial class NetSurfaceEngine : IHostedService {

        private const int ENGINE_TICK_RATE_IN_SECONDS = 3;

        private readonly ILogger<NetSurfaceEngine> _logger = null;

        public NetSurfaceEngine(ILogger<NetSurfaceEngine> logger) {
            _logger = logger;
        }

        #region IHostedService Implementation

        ///
        public async Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Entering Engine Processing Loop");
            while (!cancellationToken.IsCancellationRequested)
            {
                using (_logger.BeginScope("Inside Engine Processing Loop")) {
                    try
                    {
                        _logger.LogInformation("Perform some fun NetSurface logic here.");
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(ex, "Engine Processing Loop encountered an unexpected error");
                    }

                    _logger.LogInformation($"Suspending process loop for {ENGINE_TICK_RATE_IN_SECONDS} seconds.");
                    await Task.Delay(ENGINE_TICK_RATE_IN_SECONDS * 1000);
                }
            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("StopAsync called.");
            return Task.CompletedTask;
        }

        #endregion IHostedService Implementation
    }
}
