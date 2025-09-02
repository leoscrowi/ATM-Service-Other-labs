using Lab5.Presentation.Console.Scenarios;
using Lab5.Presentation.Console.Scenarios.CheckBalance;
using Lab5.Presentation.Console.Scenarios.CreateBankAccount;
using Lab5.Presentation.Console.Scenarios.DepositBalance;
using Lab5.Presentation.Console.Scenarios.Login;
using Lab5.Presentation.Console.Scenarios.OperationsHistory;
using Lab5.Presentation.Console.Scenarios.WithdrawBalance;
using Microsoft.Extensions.DependencyInjection;

namespace Lab5.Presentation.Console.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddPresentationConsole(this IServiceCollection services)
    {
        services.AddScoped<ScenarioRunner>();
        services.AddScoped<IScenarioProvider, LoginScenarioProvider>();
        services.AddScoped<IScenarioProvider, CreateAccountScenarioProvider>();
        services.AddScoped<IScenarioProvider, WithdrawScenarioProvider>();
        services.AddScoped<IScenarioProvider, DepositScenarioProvider>();
        services.AddScoped<IScenarioProvider, CheckBalanceScenarioProvider>();
        services.AddScoped<IScenarioProvider, OperationsHistoryScenarioProvider>();
        return services;
    }
}