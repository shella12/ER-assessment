using Microsoft.AspNetCore.SignalR;

namespace CrmScreening.Hubs;

// Task 5 — SignalR hub that broadcasts a message to every connected client.
public class NotificationHub : Hub
{
    // Called by a client; relays the message to all connected clients (all tabs).
    public async Task SendMessage(string message)
    {
        await Clients.All.SendAsync("ReceiveMessage", message);
    }
}
