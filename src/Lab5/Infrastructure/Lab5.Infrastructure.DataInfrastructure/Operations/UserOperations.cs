using Itmo.Dev.Platform.Postgres.Connection;
using Itmo.Dev.Platform.Postgres.Extensions;
using Lab5.Application.Abstractions.CurrentUserOperations;
using Lab5.Application.Models.Operations;
using Npgsql;

namespace Lab5.Infrastructure.DataInfrastructure.Operations;

public class UserOperations : IUserOperation
{
    private readonly IPostgresConnectionProvider _connectionProvider;

    public UserOperations(IPostgresConnectionProvider connectionProvider)
    {
        _connectionProvider = connectionProvider;
    }

    public decimal? CheckBalance(int accountNumber)
    {
        const string sql = """
        select balance
        from users
        where account_number = :accountNumber;
        """;

        NpgsqlConnection connection = _connectionProvider
            .GetConnectionAsync(default)
            .Preserve()
            .GetAwaiter()
            .GetResult();

        using NpgsqlCommand command = new NpgsqlCommand(sql, connection)
            .AddParameter("accountNumber", accountNumber);

        using NpgsqlDataReader reader = command.ExecuteReader();

        if (reader.Read() is false) return null;
        decimal balance = reader.GetDecimal(0);
        connection.Close();
        return balance;
    }

    public OperationsHistoryList OperationsHistory(int accountNumber)
    {
        const string sql = """
                           select operation_name, balance, datetime
                           from transactions
                           where account_number = :accountNumber
                           order by datetime
                           """;

        NpgsqlConnection connection = _connectionProvider
            .GetConnectionAsync(default)
            .Preserve()
            .GetAwaiter()
            .GetResult();

        using NpgsqlCommand command = new NpgsqlCommand(sql, connection)
            .AddParameter("accountNumber", accountNumber);

        using NpgsqlDataReader reader = command.ExecuteReader();

        var history = new List<Operation>();
        while (reader.Read())
        {
            string operationName = reader.GetString(0);
            decimal amount = reader.GetDecimal(1);
            DateTime dateTime = reader.GetDateTime(2);
            var operation = new Operation(
                AccountNumber: accountNumber,
                OperationName: operationName,
                Balance: amount,
                DateTime: dateTime);
            history.Add(operation);
        }

        connection.Close();
        return new OperationsHistoryList(history);
    }

    public void ChangeBalance(int accountNumber, decimal newBalance, string operation)
    {
        const string sql = """
        update users
        set balance = :balance
        where account_number = :accountNumber;
        """;

        NpgsqlConnection connection = _connectionProvider
            .GetConnectionAsync(default)
            .Preserve()
            .GetAwaiter()
            .GetResult();

        using NpgsqlCommand command = new NpgsqlCommand(sql, connection)
            .AddParameter("accountNumber", accountNumber)
            .AddParameter("balance", newBalance);

        using NpgsqlDataReader reader = command.ExecuteReader();
        WriteHistory(accountNumber, operation, newBalance, DateTime.Now);
        connection.Close();
    }

    private void WriteHistory(int accountNumber, string operation, decimal newBalance, DateTime dateTime)
    {
        const string sql = """
                           insert into transactions (account_number, operation_name, balance, datetime)
                           values (:accountNumber, :operationName, :balance, :datetime)
                           """;
        NpgsqlConnection connection = _connectionProvider
            .GetConnectionAsync(default)
            .Preserve()
            .GetAwaiter()
            .GetResult();

        using NpgsqlCommand command = new NpgsqlCommand(sql, connection)
            .AddParameter("accountNumber", accountNumber)
            .AddParameter("operationName", operation)
            .AddParameter("balance", newBalance)
            .AddParameter("datetime", dateTime);

        using NpgsqlDataReader reader = command.ExecuteReader();
        connection.Close();
    }
}