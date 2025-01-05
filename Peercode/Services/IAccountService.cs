using Peercode.Dtos;

namespace Peercode.Services;

public interface IAccountService
{
    Task RegisterUserAsync(RegisterDto registerDto);

    Task<LoginResponseDto> LoginUserAsync(LoginDto loginDto);
}
