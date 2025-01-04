using Microsoft.AspNetCore.SignalR;

namespace CourseApp.Infrastructure.Hubs;

internal class PayHub : Hub
{
    public static readonly IDictionary<string, string> TransactionConnections = new Dictionary<string, string>();

    public void RegisterTransaction(string id)
    {
        var connectionId = Context.ConnectionId;
        TransactionConnections[id] = connectionId;
    }

    public override Task OnDisconnectedAsync(Exception? exception)
    {
        var connectionId = Context?.ConnectionId;
        var item = TransactionConnections.FirstOrDefault(x => x.Value == connectionId);
        TransactionConnections.Remove(connectionId);
        return base.OnDisconnectedAsync(exception);
    }
}
