using Autofac;
using Peercode.Core;
using Peercode.Core.Repositories;
using Peercode.Persistance.Repositories;

namespace Peercode.Persistance;

internal class UnitOfWork(ILifetimeScope lifetimeScope) : IUnitOfWork
{
    public IUserRepository UserRepository => lifetimeScope.Resolve<UserRepository>();
}
