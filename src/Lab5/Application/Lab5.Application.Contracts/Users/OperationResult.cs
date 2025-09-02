using Lab5.Application.Models.Operations;

namespace Lab5.Application.Contracts.Users;

public abstract record OperationResult
{
    private OperationResult() { }

    public sealed record BalanceCheckSuccess : OperationResult
    {
        public decimal Balance { get; private init; }

        public BalanceCheckSuccess(decimal balance)
        {
            Balance = balance;
        }
    }

    public sealed record HistorySuccess : OperationResult
    {
        public OperationsHistoryList History { get; private init; }

        public HistorySuccess(OperationsHistoryList history)
        {
            History = history;
        }
    }

    public sealed record Success : OperationResult;

    public sealed record Failure : OperationResult;

    public sealed record NotEnoughBalance : OperationResult;

    public sealed record NotLoggedIn : OperationResult;
}