using System.Text.Json;
using Peercode.Core.Enums;
using Peercode.Dtos.WebSockets;

namespace Peercode.Services.Implementations.WebSockets;

public class GroupChatWebSocketService : BaseWebSocketService
{
    public override WebSocketTopic Topic => WebSocketTopic.GroupChat;

    public override Task ProcessAsync(string message)
    {
        var groupChatWebSocketDto = JsonSerializer.Deserialize<GroupChatWebSocketDto>(message);
        throw new NotImplementedException();
    }
}
