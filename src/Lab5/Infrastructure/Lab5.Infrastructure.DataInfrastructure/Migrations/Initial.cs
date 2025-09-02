using FluentMigrator;
using Itmo.Dev.Platform.Postgres.Migrations;

namespace Lab5.Infrastructure.DataInfrastructure.Migrations;

[Migration(1, "Initial")]
public class Initial : SqlMigration
{
    protected override string GetUpSql(IServiceProvider serviceProvider) =>
    """
    create type user_role as enum
    (
        'admin',
        'user'
    );
    
    create type operation_name as enum
    (
        'withdraw',
        'deposit'
    );

    create table users
    (
        account_number int primary key ,
        pin_code int not null ,
        user_role user_role not null ,
        balance decimal not null ,
        password text
    );
    
    create table transactions
    (
        account_number int ,
        operation_name text not null ,
        balance int not null ,
        datetime timestamp not null
    );
    """;

    protected override string GetDownSql(IServiceProvider serviceProvider) =>
    """
    drop table users;
    drop table transactions;

    drop type user_role;
    drop type operation_name;
    """;
}