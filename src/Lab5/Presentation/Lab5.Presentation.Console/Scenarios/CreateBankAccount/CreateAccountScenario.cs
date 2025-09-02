using Lab5.Application.Contracts.Users;
using Spectre.Console;

namespace Lab5.Presentation.Console.Scenarios.CreateBankAccount;

public class CreateAccountScenario : IScenario
{
    private readonly IUserService _userService;

    public CreateAccountScenario(IUserService userService)
    {
        _userService = userService;
    }

    public string Name => "Create bank account";

    public void Run()
    {
        int accountNumber = AnsiConsole.Prompt(
            new TextPrompt<int>("Enter Account Number: "));
        int pinCode = AnsiConsole.Prompt(
            new TextPrompt<int>("Enter Pin code: "));
        LoginResult? result;
        result = _userService.CreateAccount(accountNumber, pinCode);

        string message = result switch
        {
            LoginResult.Success => "Account created successfully",
            LoginResult.Failure => "Failed to create account.",
            LoginResult.WrongPassword => throw new InvalidOperationException("Wrong password"),
            _ => throw new ArgumentOutOfRangeException(nameof(result)),
        };

        AnsiConsole.WriteLine(message);
    }
}