using Microsoft.AspNetCore.SignalR;

namespace P238SignalR.Hubs
{
    public class ChatHub : Hub
    {
        private static int Counter = 0;

        public async Task SendMessageAsync(string userName, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage",userName, message);
        }

        public override async Task OnConnectedAsync()
        {
            Counter++;  
            await Clients.All.SendAsync("UserCounter", Counter);

            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            Counter--;
            await Clients.All.SendAsync("UserCounter", Counter);

            await base.OnDisconnectedAsync(exception);
        }
    }
}
