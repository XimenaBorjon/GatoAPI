using Microsoft.AspNetCore.SignalR;
namespace GatoAPI.Services
{
    public class GatoHub:Hub
    {
        public async Task SendMove(int index, string selectedText)
        {
            await Clients.All.SendAsync("ReceiveMove", index, selectedText);
        }
    }
}
