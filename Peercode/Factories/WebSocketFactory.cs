using Peercode.Core.Enums;
using Peercode.Services;

namespace Peercode.Factories;

public class WebSocketFactory(IEnumerable<IWebSocketService> webSocketServices)
{
    public IWebSocketService GetWebSocketService(WebSocketTopic topic)
    {
        return webSocketServices.FirstOrDefault(service => service.Topic == topic)
            ?? throw new NotImplementedException();
    }
}
