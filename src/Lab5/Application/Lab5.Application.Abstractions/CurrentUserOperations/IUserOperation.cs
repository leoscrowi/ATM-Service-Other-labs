using Lab5.Application.Models.Operations;

namespace Lab5.Application.Abstractions.CurrentUserOperations;

public interface IUserOperation
{
    decimal? CheckBalance(int accountNumber);

    OperationsHistoryList OperationsHistory(int accountNumber);

    void ChangeBalance(int accountNumber, decimal newBalance, string operation);
}