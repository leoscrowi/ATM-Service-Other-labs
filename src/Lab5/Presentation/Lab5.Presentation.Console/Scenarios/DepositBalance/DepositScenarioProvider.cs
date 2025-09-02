using Lab5.Application.Contracts.Users;
using System.Diagnostics.CodeAnalysis;

namespace Lab5.Presentation.Console.Scenarios.DepositBalance;

public class DepositScenarioProvider : IScenarioProvider
{
    private readonly ICurrentUserService _currentUserService;

    public DepositScenarioProvider(
        ICurrentUserService currentUserService)
    {
        _currentUserService = currentUserService;
    }

    public bool TryGetScenario([NotNullWhen(true)] out IScenario? scenario)
    {
        if (_currentUserService.User is null)
        {
            scenario = null;
            return false;
        }

        scenario = new DepositScenario(_currentUserService);
        return true;
    }
}