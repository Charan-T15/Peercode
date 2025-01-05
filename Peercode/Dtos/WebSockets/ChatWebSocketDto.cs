using Peercode.Core.Enums;

namespace Peercode.Dtos.WebSockets
{
    public class ChatWebSocketDto : WebSocketDto
    {
        public WebSocketTopic Topic { get; set; }

        public Guid ToUserId { get; set; }

        public string Message { get; set; } = string.Empty;
    }
}
