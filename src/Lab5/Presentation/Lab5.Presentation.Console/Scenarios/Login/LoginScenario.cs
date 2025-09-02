using Lab5.Application.Contracts.Users;
using Lab5.Application.Models.Users;
using Spectre.Console;

namespace Lab5.Presentation.Console.Scenarios.Login;

public class LoginScenario : IScenario
{
    private readonly IUserService _userService;

    public LoginScenario(IUserService userService)
    {
        _userService = userService;
    }

    public string Name => "Login";

    private static readonly string[] Choices = new[] { "User", "Admin" };

    public void Run()
    {
        string userRole = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("Choose user role to login")
                .AddChoices(Choices));
        Enum.TryParse(userRole, out UserRole selectedRole);
        LoginResult? result = null;

        if (selectedRole == UserRole.Admin)
        {
            string password = AnsiConsole.Prompt(new TextPrompt<string>("Enter administrator password"));
            result = _userService.LoginAsAdmin(password);
        }
        else if (selectedRole == UserRole.User)
        {
            int accountNumber = AnsiConsole.Prompt(new TextPrompt<int>("Enter user's account number: "));
            int pinCode = AnsiConsole.Prompt(new TextPrompt<int>("Enter pin code: "));
            result = _userService.LoginAsUser(accountNumber, pinCode);
        }

        string message = result switch
        {
            LoginResult.Success => $"Successful. You are logged in.",
            LoginResult.Failure => "Failure. Try again.",
            _ => throw new ArgumentOutOfRangeException(nameof(result)),
        };

        AnsiConsole.WriteLine(message);
    }
}