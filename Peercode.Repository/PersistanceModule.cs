using Autofac;
using Peercode.Core;
using Peercode.Core.Repositories;
using Peercode.Persistance.Repositories;

namespace Peercode.Persistance;

public class PersistanceModule : Module
{
    public void Load(ContainerBuilder builder)
    {
        builder.RegisterType<PeercodeDbContext>();
        builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();
        builder.RegisterType<UserRepository>().As<IUserRepository>();
    }
}
