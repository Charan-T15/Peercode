using System.Net.WebSockets;

namespace Peercode;

public interface IWebSocketHandler
{
    public Task Handle(Guid userId, WebSocket webSocket);

    Task SendMessage(List<Guid> userIds, string message);
}
