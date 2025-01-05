using Peercode.Core.Models;

namespace Peercode.Core.Repositories;

public interface IUserRepository
{
    Task AddUserAsync(User user);

    Task<User> GetUserAsync(Guid userId);

    Task UpdateUserAsync(User user);

    Task DeleteUserAsync(Guid userId);
}
