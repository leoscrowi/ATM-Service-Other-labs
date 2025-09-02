using Lab5.Application.Contracts.Users;
using Spectre.Console;

namespace Lab5.Presentation.Console.Scenarios.OperationsHistory;

public class OperationsHistoryScenario : IScenario
{
    private readonly ICurrentUserService _currentUserService;

    public OperationsHistoryScenario(ICurrentUserService currentUserService)
    {
        _currentUserService = currentUserService;
    }

    public string Name => "History";

    public void Run()
    {
        var result = (OperationResult.HistorySuccess)_currentUserService.History();
        string message = result switch
        {
            OperationResult.HistorySuccess => result.History.ToString(),
            _ => throw new ArgumentOutOfRangeException(nameof(result)),
        };

        AnsiConsole.WriteLine(message);
    }
}