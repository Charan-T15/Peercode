using Peercode.Core.Enums;
namespace Peercode.Services;

public interface IWebSocketService
{
    WebSocketTopic Topic { get; }

    Task ProcessAsync(string message);
}
