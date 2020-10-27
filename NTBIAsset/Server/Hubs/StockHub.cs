using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace NTBIAsset.Server.Hubs
{
    public class StockHub : Hub
    {
        public async Task SendMessage()
        {
            await Clients.All.SendAsync("StockReceiveMessage");
        }
    }
}
