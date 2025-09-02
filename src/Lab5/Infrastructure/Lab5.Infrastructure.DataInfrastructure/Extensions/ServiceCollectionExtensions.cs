using Itmo.Dev.Platform.Common.Extensions;
using Itmo.Dev.Platform.Postgres.Extensions;
using Itmo.Dev.Platform.Postgres.Models;
using Itmo.Dev.Platform.Postgres.Plugins;
using Lab5.Application.Abstractions.CurrentUserOperations;
using Lab5.Application.Abstractions.Repositories;
using Lab5.Infrastructure.DataInfrastructure.Operations;
using Lab5.Infrastructure.DataInfrastructure.Plugins;
using Lab5.Infrastructure.DataInfrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Lab5.Infrastructure.DataInfrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructureDataAccess(
        this IServiceCollection services,
        Action<PostgresConnectionConfiguration> configuration)
    {
        services.AddPlatform();
        services.AddPlatformPostgres(builder => builder.Configure(configuration));
        services.AddPlatformMigrations(typeof(ServiceCollectionExtensions).Assembly);

        services.AddSingleton<IDataSourcePlugin, MappingPlugin>();

        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IUserOperation, UserOperations>();

        return services;
    }
}