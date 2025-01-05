using System.Net.WebSockets;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Peercode.Controllers;

[Authorize]
[Route("api/ws")]
public class WebSocketsController(IWebSocketHandler webSocketHandler) : ControllerBase
{
    public async Task GetChatSocket()
    {
        if (this.HttpContext.WebSockets.IsWebSocketRequest)
        {
            var webSocket = await this.HttpContext.WebSockets.AcceptWebSocketAsync();
            var userId = Guid.Parse(this.HttpContext.User.Claims.First().Value);
            await webSocketHandler.Handle(userId, webSocket);
        }
        else
        {
            this.HttpContext.Response.StatusCode = 400;
        }
    }
}
