using Lab5.Application.Contracts.Users;
using Spectre.Console;

namespace Lab5.Presentation.Console.Scenarios.DepositBalance;

public class DepositScenario : IScenario
{
    private readonly ICurrentUserService _currentUserService;

    public DepositScenario(ICurrentUserService currentUserService)
    {
        _currentUserService = currentUserService;
    }

    public string Name => "Deposit";

    public void Run()
    {
        decimal withdrawAmount = AnsiConsole.Prompt(
            new TextPrompt<decimal>("Deposit amount: "));
        OperationResult? result;
        result = _currentUserService.Deposit(withdrawAmount);

        string message = result switch
        {
            OperationResult.Success => "Deposit successful",
            OperationResult.Failure => "Failed. Try again",
            OperationResult.NotLoggedIn => "Not logged in",
            _ => throw new ArgumentOutOfRangeException(nameof(result)),
        };

        AnsiConsole.WriteLine(message);
    }
}