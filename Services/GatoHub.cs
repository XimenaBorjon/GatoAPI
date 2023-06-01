using GatoAPI.Models;
using Microsoft.AspNetCore.SignalR;
namespace GatoAPI.Services
{
    public static class UserHandler
    {
        public static HashSet<string> ConnectedIds = new HashSet<string>();
    }
    public class GatoHub:Hub
    {
        public class MyHub : Hub
        {

            public override Task OnConnectedAsync()
            {
                UserHandler.ConnectedIds.Add(Context.ConnectionId);
                return base.OnConnectedAsync();
            }

            public override Task OnDisconnectedAsync(Exception? exception)
            {
                UserHandler.ConnectedIds.Remove(Context.ConnectionId);
                return base.OnDisconnectedAsync(exception);
            }
        }
        public async Task SendMove(int index, string selectedText, byte turn)
        {
            await Clients.All.SendAsync("ReceiveMove", index, selectedText, turn);
        }
        public async Task SendFirstMove(int index, string selectedText, string connectionId)
        {
            await Clients.All.SendAsync("ReceiveMove", index, selectedText, 0);
            await Clients.AllExcept(connectionId).SendAsync("SetTurn");
        }

        public async void Join(Jugador j, string id)
        {
            if(UserHandler.ConnectedIds.Count==2)
            {
                await Clients.Client(id).SendAsync("SalaLlena", true);
            }
            else
            {

            }
        }
    }
}
