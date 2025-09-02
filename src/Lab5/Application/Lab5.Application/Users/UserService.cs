using Lab5.Application.Abstractions.Repositories;
using Lab5.Application.Contracts.Users;
using Lab5.Application.Models.Users;

namespace Lab5.Application.Users;

internal class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly CurrentUserManager _currentUserManager;

    public UserService(IUserRepository userRepository, CurrentUserManager currentUserManager)
    {
        _userRepository = userRepository;
        _currentUserManager = currentUserManager;
    }

    public LoginResult LoginAsUser(int accountNumber, int pinCode)
    {
        User? user = _userRepository.GetUserByAccountNumber(accountNumber, pinCode);

        if (user == null) return new LoginResult.Failure();

        _currentUserManager.User = user;
        return new LoginResult.Success();
    }

    public LoginResult LoginAsAdmin(string password)
    {
        User? user = _userRepository.GetUserByPassword(password);

        if (user == null) return new LoginResult.WrongPassword();

        _currentUserManager.User = user;
        return new LoginResult.Success();
    }

    public LoginResult CreateAccount(int accountNumber, int pinCode)
    {
        User? user = _userRepository.CreateUser(accountNumber, pinCode);

        if (user == null) return new LoginResult.Failure();

        _currentUserManager.User = user;
        return new LoginResult.Success();
    }
}