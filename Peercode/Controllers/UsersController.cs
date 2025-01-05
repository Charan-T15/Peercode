using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Peercode.Dtos;
using Peercode.Services;

namespace Peercode.Controllers;

[Authorize]
[Route("api/users")]
public class UsersController(IUserService userService) : ControllerBase
{
    [HttpGet("{userId:Guid}")]
    public async Task<IActionResult> GetUserAsync(Guid userId)
    {
        var user = await userService.GetUserAsync(userId);
        return this.Ok(user);
    }

    [HttpPut("{userId:Guid}")]
    public async Task UpdateUserAsync(Guid userId, UserUpdateDto userUpdateDto)
    {
        await userService.UpdateUserAsync(userId, userUpdateDto);
    }
}
