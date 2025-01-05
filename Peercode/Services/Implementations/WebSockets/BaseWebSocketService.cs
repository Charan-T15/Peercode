using Peercode.Core.Enums;
using Peercode.Dtos.WebSockets;

namespace Peercode.Services.Implementations.WebSockets;

public abstract class BaseWebSocketService : IWebSocketService
{ 
    public abstract WebSocketTopic Topic { get; }

    public abstract Task ProcessAsync(string message);
}
