using Lab5.Application.Abstractions.CurrentUserOperations;
using Lab5.Application.Contracts.Users;
using Lab5.Application.Models.Operations;
using Lab5.Application.Models.Users;

namespace Lab5.Application.Users;

internal class CurrentUserManager : ICurrentUserService
{
    private readonly IUserOperation _userOperations;

    public CurrentUserManager(IUserOperation userOperations)
    {
        _userOperations = userOperations;
    }

    public User? User { get; set; }

    public OperationResult CheckBalance()
    {
        if (User == null) return new OperationResult.Failure();
        decimal? balance = _userOperations.CheckBalance(User.AccountNumber);
        if (balance is null) return new OperationResult.Failure();
        return new OperationResult.BalanceCheckSuccess(balance.Value);
    }

    public OperationResult Deposit(decimal amount)
    {
        var result = (OperationResult.BalanceCheckSuccess)CheckBalance();
        if (User == null) return new OperationResult.Failure();
        _userOperations.ChangeBalance(User.AccountNumber, result.Balance + amount, "deposit");
        return new OperationResult.Success();
    }

    public OperationResult Withdraw(decimal amount)
    {
        if (User == null) return new OperationResult.NotLoggedIn();
        var result = (OperationResult.BalanceCheckSuccess)CheckBalance();
        if (result.Balance - amount < 0) return new OperationResult.NotEnoughBalance();
        _userOperations.ChangeBalance(User.AccountNumber, result.Balance - amount, "withdraw");
        return new OperationResult.Success();
    }

    public OperationResult History()
    {
        if (User == null) return new OperationResult.NotLoggedIn();
        OperationsHistoryList history = _userOperations.OperationsHistory(User.AccountNumber);
        return new OperationResult.HistorySuccess(history);
    }
}