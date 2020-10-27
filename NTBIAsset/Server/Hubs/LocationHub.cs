using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace NTBIAsset.Server.Hubs
{
    public class LocationHub : Hub
    {
        public async Task SendMessage()
        {
            await Clients.All.SendAsync("ReceiveMessage");
        }
    }
}
