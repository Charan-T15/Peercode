using System.Net.WebSockets;
using System.Text;
using System.Text.Json;
using Peercode.Dtos.WebSockets;
using Peercode.Factories;

namespace Peercode;

public class WebSocketHandler(WebSocketFactory webSocketFactory) : IWebSocketHandler
{
    private readonly Dictionary<Guid, List<WebSocket>> ActiveWebSockets = new();

    public async Task Handle(Guid userId, WebSocket webSocket)
    {
        
        this.AddToActiveWebSockets(userId, webSocket);
        while (webSocket.State != WebSocketState.Open)
        {
            await this.RecieveMessage(webSocket);
        }
        this.RemoveFromActiveWebSockets(userId, webSocket);
    }

    public async Task SendMessage(List<Guid> userIds, string message)
    {
        var bytes = Encoding.Default.GetBytes(message);
        var arraysegments = new ArraySegment<byte>(bytes);
        var websockets = this.ActiveWebSockets
            .Where(socketPair => userIds.Contains(socketPair.Key))
            .SelectMany(sockets => sockets.Value).ToList() ?? [];

        var tasks = websockets.Select(socket => socket.SendAsync(arraysegments, WebSocketMessageType.Text, true, CancellationToken.None));
        await Task.WhenAll(tasks);
    }

    private async Task RecieveMessage(WebSocket socket)
    {
        var arraySegments = new ArraySegment<byte>(new byte[4096]);
        var recievedMessage = await socket.ReceiveAsync(arraySegments, CancellationToken.None);
        if (recievedMessage != null)
        {
            var message = Encoding.Default.GetString(arraySegments);
            var webSocketDto = JsonSerializer.Deserialize<WebSocketDto>(message);
            var webSocketService = webSocketFactory.GetWebSocketService(webSocketDto!.Topic);
            await webSocketService.ProcessAsync(webSocketDto.Message);
        }
    }

    private void RemoveFromActiveWebSockets(Guid userId, WebSocket websocket)
    {
        lock (ActiveWebSockets)
        {
            this.ActiveWebSockets.GetValueOrDefault(userId)?.Remove(websocket);
        }
    }

    private void AddToActiveWebSockets(Guid userId, WebSocket webSocket)
    {
        lock (ActiveWebSockets)
        {
            if (ActiveWebSockets.TryGetValue(userId, out List<WebSocket>? sockets))
            {
                sockets.Add(webSocket);
            }
            else
            {
                ActiveWebSockets.Add(userId, [webSocket]);
            }
        }
    }
}
