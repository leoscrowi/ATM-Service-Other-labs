using Lab5.Application.Models.Users;

namespace Lab5.Application.Contracts.Users;

public interface ICurrentUserService
{
    User? User { get; }

    OperationResult CheckBalance();

    OperationResult Deposit(decimal amount);

    OperationResult Withdraw(decimal amount);

    OperationResult History();
}