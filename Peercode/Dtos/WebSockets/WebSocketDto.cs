using Peercode.Core.Enums;

namespace Peercode.Dtos.WebSockets;

public class WebSocketDto
{
    public WebSocketTopic Topic { get; set; }

    public string Message { get; set; }
}
