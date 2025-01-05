using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Peercode.Persistance;

public static class Extensions
{
    public static IServiceCollection AddAccountsDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AccountsDbContext>(options => options.ConfigureAccountsDbContext(configuration));
        return services;
    }

    private static void ConfigureAccountsDbContext(this DbContextOptionsBuilder options, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("AccountsDb");
        options.UseSqlServer(connectionString);
    }
}
