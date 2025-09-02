using Lab5.Application.Contracts.Users;
using Lab5.Application.Users;
using Microsoft.Extensions.DependencyInjection;

namespace Lab5.Application.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IUserService, UserService>();

        services.AddScoped<CurrentUserManager>();
        services.AddScoped<ICurrentUserService>(p => p.GetRequiredService<CurrentUserManager>());

        return services;
    }
}