using Microsoft.AspNetCore.Mvc;
using Peercode.Dtos;
using Peercode.Services;

namespace Peercode.Controllers;

[Route("api/accounts")]
[ApiController]
public class AccountsController(IAccountService accountService) : ControllerBase
{
    [HttpPost("register")]
    public async Task<IActionResult> RegisterUserAsync(RegisterDto registerDto)
    {
        await accountService.RegisterUserAsync(registerDto);
        return this.Ok();
    }

    [HttpPost("login")]
    public async Task<IActionResult> LoginUserAsync(LoginDto loginDto)
    {
        var loginResponseDto = await accountService.LoginUserAsync(loginDto);
        return this.Ok(loginResponseDto);
    }
}
