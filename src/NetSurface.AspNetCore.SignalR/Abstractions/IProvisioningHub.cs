using System;
using System.Threading.Tasks;

namespace NetSurface.AspNetCore.SignalR.Abstractions
{
    public interface IProvisioningHub {
        Task BeginPollingForDocker();
        Task ReceiveStatusMessage(DateTime dateTime, string message);
    }
}
