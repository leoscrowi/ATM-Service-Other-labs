using Lab5.Application.Contracts.Users;
using Spectre.Console;

namespace Lab5.Presentation.Console.Scenarios.CheckBalance;

public class CheckBalanceScenario : IScenario
{
    private readonly ICurrentUserService _currentUserService;

    public CheckBalanceScenario(ICurrentUserService currentUserService)
    {
        _currentUserService = currentUserService;
    }

    public string Name => "Check Balance";

    public void Run()
    {
        var result = (OperationResult.BalanceCheckSuccess)_currentUserService.CheckBalance();
        string message = result switch
        {
            OperationResult.BalanceCheckSuccess => "Balance check success. Your balance: " + result.Balance,
            _ => throw new ArgumentOutOfRangeException(nameof(result)),
        };
        AnsiConsole.WriteLine(message);
    }
}