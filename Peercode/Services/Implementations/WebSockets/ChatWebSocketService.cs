using System.Text.Json;
using Peercode.Core.Enums;
using Peercode.Dtos.WebSockets;

namespace Peercode.Services.Implementations.WebSockets;

public class ChatWebSocketService(IWebSocketHandler webSocketHandler) : BaseWebSocketService
{
    public override WebSocketTopic Topic => WebSocketTopic.Chat;

    public override async Task ProcessAsync(string message)
    {
        var chatWebSocketDto = JsonSerializer.Deserialize<ChatWebSocketDto>(message);
        await webSocketHandler.SendMessage([chatWebSocketDto!.ToUserId], chatWebSocketDto.Message);
    }
}
