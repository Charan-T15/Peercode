using Autofac;
using Peercode.Factories;
using Peercode.Services;
using Peercode.Services.Implementations;
using Peercode.Services.Implementations.WebSockets;

namespace Peercode;

public class WebApiModule : Module
{
    public void Load(ContainerBuilder builder)
    {
        builder.RegisterType<AccountService>().As<IAccountService>().InstancePerLifetimeScope();
        builder.RegisterType<UserService>().As<IUserService>().InstancePerLifetimeScope();
        this.RegisterWebSocketEntities(builder);
    }

    private void RegisterWebSocketEntities(ContainerBuilder builder)
    {
        builder.RegisterType<WebSocketHandler>().As<IWebSocketHandler>().SingleInstance();
        builder.RegisterType<ChatWebSocketService>().As<IWebSocketService>().InstancePerLifetimeScope();
        builder.RegisterType<GroupChatWebSocketService>().As<IWebSocketService>().InstancePerLifetimeScope();
        builder.RegisterType<WebSocketFactory>().AsSelf().InstancePerLifetimeScope();
    }
}
