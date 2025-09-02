using Lab5.Application.Models.Users;

namespace Lab5.Application.Abstractions.Repositories;

public interface IUserRepository
{
    User? GetUserByAccountNumber(int accountNumber, int pinCode);

    User? GetUserByPassword(string password);

    User? CreateUser(int accountNumber, int pinCode);
}