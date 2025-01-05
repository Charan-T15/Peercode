using Peercode.Core.Enums;

namespace Peercode.Dtos.WebSockets;

public class GroupChatWebSocketDto : WebSocketDto
{
    public WebSocketTopic Topic { get; set; }

    public Guid GroupId { get; set; }

    public string Message { get; set; } = string.Empty;
}
