using Lab5.Application.Contracts.Users;
using Spectre.Console;

namespace Lab5.Presentation.Console.Scenarios.WithdrawBalance;

public class WithdrawScenario : IScenario
{
    private readonly ICurrentUserService _currentUserService;

    public WithdrawScenario(ICurrentUserService currentUserService)
    {
        _currentUserService = currentUserService;
    }

    public string Name => "Withdraw";

    public void Run()
    {
        decimal withdrawAmount = AnsiConsole.Prompt(
            new TextPrompt<decimal>("Withdraw amount: "));
        OperationResult? result;
        result = _currentUserService.Withdraw(withdrawAmount);

        string message = result switch
        {
            OperationResult.Success => "Withdrawn",
            OperationResult.Failure => "Failed. Try again",
            OperationResult.NotEnoughBalance => "Not enough balance",
            OperationResult.NotLoggedIn => "Not logged in",
            _ => throw new ArgumentOutOfRangeException(nameof(result)),
        };

        AnsiConsole.WriteLine(message);
    }
}