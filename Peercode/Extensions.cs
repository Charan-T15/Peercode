using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Peercode.Persistance;
using Microsoft.AspNetCore.Authentication;
using Autofac.Extensions.DependencyInjection;
using Autofac;
using AutoMapper.Contrib.Autofac.DependencyInjection;

namespace Peercode;

public static class Extensions
{
    public static IServiceCollection AddIdentity(this IServiceCollection services)
    {
        services
            .AddIdentity<IdentityUser, IdentityRole>(options => options.ConfigureIdentity())
            .AddEntityFrameworkStores<AccountsDbContext>()
            .AddDefaultTokenProviders();
        return services;
    }

    public static IServiceCollection AddAuthentication(this IServiceCollection services, IConfiguration configuration)
    {
        services
            .AddAuthentication(options => options.ConfigureAuthentication())
            .AddJwtBearer(options => options.ConfigureJwtBearer(configuration));
        return services;
    }

    public static IHostBuilder ConfigureHost(this IHostBuilder builder, IConfiguration configuration)
    {
        builder
            .UseServiceProviderFactory(new AutofacServiceProviderFactory())
            .ConfigureContainer<ContainerBuilder>(builder =>
            {
                builder.RegisterModule(new WebApiModule());
                builder.RegisterModule(new PersistanceModule());
                builder.RegisterAutoMapper(typeof(DtoMapperProfile).Assembly);
                builder.RegisterAutoMapper(typeof(DataMapperProfile).Assembly);
            });
        return builder;
    }

    private static void ConfigureIdentity(this IdentityOptions options)
    {
        options.Password.RequiredLength = 6;
        options.Password.RequireNonAlphanumeric = true;
        options.Password.RequireDigit = true;
        options.Password.RequireLowercase = true;
        options.Password.RequireUppercase = true;
    }

    private static void ConfigureAuthentication(this AuthenticationOptions options)
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    }

    private static void ConfigureJwtBearer(this JwtBearerOptions options, IConfiguration configuration)
    {
        options.TokenValidationParameters = new()
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = configuration["Jwt:Issuer"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration.GetSection("Jwt:Key").Value!)),
        };
    }

}
