namespace Lab5.Application.Models.Users;

public record User(int AccountNumber, int PinCode, UserRole UserRole, decimal Balance, string? Password);