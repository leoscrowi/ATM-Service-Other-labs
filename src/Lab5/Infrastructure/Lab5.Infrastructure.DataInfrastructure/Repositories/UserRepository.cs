using Itmo.Dev.Platform.Postgres.Connection;
using Itmo.Dev.Platform.Postgres.Extensions;
using Lab5.Application.Abstractions.Repositories;
using Lab5.Application.Models.Users;
using Npgsql;

namespace Lab5.Infrastructure.DataInfrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly IPostgresConnectionProvider _connectionProvider;

    public UserRepository(IPostgresConnectionProvider connectionProvider)
    {
        _connectionProvider = connectionProvider;
    }

    public User? GetUserByAccountNumber(int accountNumber, int pinCode)
    {
        const string sql = """
        select account_number, pin_code, user_role, balance
        from users
        where account_number = :accountNumber and pin_code = :pinCode;
        """;

        NpgsqlConnection connection = _connectionProvider
            .GetConnectionAsync(default)
            .Preserve()
            .GetAwaiter()
            .GetResult();

        using NpgsqlCommand command = new NpgsqlCommand(sql, connection)
            .AddParameter("accountNumber", accountNumber)
            .AddParameter("pinCode", pinCode);

        using NpgsqlDataReader reader = command.ExecuteReader();

        if (reader.Read() is false) return null;
        return new User(
                AccountNumber: reader.GetInt32(0),
                PinCode: reader.GetInt32(1),
                UserRole: reader.GetFieldValue<UserRole>(2),
                Balance: reader.GetDecimal(3),
                Password: null);
    }

    public User? GetUserByPassword(string password)
    {
        const string sql = """
                           select account_number, pin_code, user_role, balance, password
                           from users
                           where password = :password;
                           """;

        NpgsqlConnection connection = _connectionProvider
            .GetConnectionAsync(default)
            .Preserve()
            .GetAwaiter()
            .GetResult();

        using NpgsqlCommand command = new NpgsqlCommand(sql, connection)
            .AddParameter("password", password);

        using NpgsqlDataReader reader = command.ExecuteReader();

        if (reader.Read() is false) return null;
        connection.Close();
        return new User(
            AccountNumber: reader.GetInt32(0),
            PinCode: reader.GetInt32(1),
            UserRole: reader.GetFieldValue<UserRole>(2),
            Balance: reader.GetDecimal(3),
            Password: reader.GetString(4));
    }

    public User? CreateUser(int accountNumber, int pinCode)
    {
        const string sql = """
                           select account_number from users
                           where account_number = :account_number
                           """;

        NpgsqlConnection connection = _connectionProvider
            .GetConnectionAsync(default)
            .Preserve()
            .GetAwaiter()
            .GetResult();

        using NpgsqlCommand getCommand = new NpgsqlCommand(sql, connection)
            .AddParameter("account_number", accountNumber);

        using NpgsqlDataReader getReader = getCommand.ExecuteReader();
        bool exists = getReader.HasRows;
        if (exists) return null;
        getReader.Close();

        const string sqlInsert = """
                                 insert into users (account_number, pin_code, user_role, balance, password)
                                 values (:accountNumber, :pinCode, 'user', 0, null)
                                 """;

        using NpgsqlCommand insertCommand = new NpgsqlCommand(sqlInsert, connection)
            .AddParameter("accountNumber", accountNumber)
            .AddParameter("pinCode", pinCode);

        using NpgsqlDataReader insertReader = insertCommand.ExecuteReader();
        return new User(
            AccountNumber: accountNumber,
            PinCode: pinCode,
            UserRole: UserRole.User,
            Balance: 0,
            Password: null);
    }
}