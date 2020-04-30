using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Hosting;
using System;
using Microsoft.AspNetCore.SignalR.Client;

namespace NetSurface.AspNetCore.Host.HostedServices
{
    //
    // Summary:
    //     
    public partial class NetSurfaceEngine : IHostedService {

        private const int ENGINE_TICK_RATE_IN_SECONDS = 3;

        private const string PROVISIONING_HUB_URL = "https://localhost:5001/provisioning-hub";

        private HubConnection _provisioningHubConnection;

        private readonly ILogger<NetSurfaceEngine> _logger = null;

        public NetSurfaceEngine(ILogger<NetSurfaceEngine> logger) {
            _logger = logger;
        }

        #region IHostedService Implementation

        ///
        public async Task StartAsync(CancellationToken cancellationToken)
        {
            ConfigureProvisioningHub();

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

        #region Private Methods

        private void ConfigureProvisioningHub() {

            _provisioningHubConnection = new HubConnectionBuilder()
                                                .WithUrl(PROVISIONING_HUB_URL)
                                                .Build();

            _provisioningHubConnection.On("ToggleUserProviders", ToggleUserProviders);
            _provisioningHubConnection.On("ToggleUserCapabilities", ToggleUserCapabilities);
        }

        private Task ToggleUserProviders() {
            _logger.LogInformation("ToggleUserProviders");
            return Task.CompletedTask;
        }

        private Task ToggleUserCapabilities() {
            _logger.LogInformation("ToggleUserCapabilities");
            return Task.CompletedTask;
        }

        #endregion Private Methods
    }
}
