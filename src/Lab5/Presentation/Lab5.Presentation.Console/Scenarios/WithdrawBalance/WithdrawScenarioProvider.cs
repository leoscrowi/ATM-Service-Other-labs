using Lab5.Application.Contracts.Users;
using System.Diagnostics.CodeAnalysis;

namespace Lab5.Presentation.Console.Scenarios.WithdrawBalance;

public class WithdrawScenarioProvider : IScenarioProvider
{
    private readonly ICurrentUserService _currentUserService;

    public WithdrawScenarioProvider(
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

        scenario = new WithdrawScenario(_currentUserService);
        return true;
    }
}