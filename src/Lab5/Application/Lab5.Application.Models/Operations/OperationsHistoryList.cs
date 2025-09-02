namespace Lab5.Application.Models.Operations;

public class OperationsHistoryList
{
    private readonly IEnumerable<Operation> _history;

    public OperationsHistoryList(IEnumerable<Operation> history)
    {
        _history = history;
    }

    public override string ToString()
    {
        if (!_history.Any())
        {
            return "History is empty";
        }

        string result = "History:" + Environment.NewLine;
        foreach (Operation operation in _history)
        {
            result += "Operation: " + operation.OperationName + " | New Balance: " + operation.Balance;
            result += Environment.NewLine;
        }

        return result;
    }
}