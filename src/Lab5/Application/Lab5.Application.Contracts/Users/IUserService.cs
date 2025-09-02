namespace Lab5.Application.Contracts.Users;

public interface IUserService
{
    LoginResult LoginAsUser(int accountNumber, int pinCode);

    LoginResult LoginAsAdmin(string password);

    LoginResult CreateAccount(int accountNumber, int pinCode);
}