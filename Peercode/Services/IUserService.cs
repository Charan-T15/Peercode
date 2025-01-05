using Peercode.Core.Models;
using Peercode.Dtos;

namespace Peercode.Services;

public interface IUserService
{
    Task AddUserAsync(Register register);

    Task<UserDetailsDto> GetUserAsync(Guid userId);

    Task UpdateUserAsync(Guid userId, UserUpdateDto userUpdateDto);
}
