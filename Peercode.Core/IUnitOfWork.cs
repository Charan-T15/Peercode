using Peercode.Core.Repositories;

namespace Peercode.Core;

public interface IUnitOfWork
{
    IUserRepository UserRepository { get; }
}
