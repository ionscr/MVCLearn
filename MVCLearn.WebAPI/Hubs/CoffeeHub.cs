using Microsoft.AspNetCore.SignalR;
using System.Threading;
using System.Threading.Tasks;

namespace MVCLearn.WebAPI.Hubs
{
    public class CoffeeHub : Hub
    {
        public async Task GetUpdate()
        {
            int i = 0;
            do
            {
                var result = $"New Result {i}";
                Thread.Sleep(1000);
                await Clients.Caller.SendAsync("ReceiveOrderUpdate",
                        result);
                i++;
            } while (i < 20);
            await Clients.Caller.SendAsync("Finished");
        }
    }
}
