namespace Itmo.ObjectOrientedProgramming.Lab2.Users.Builders;

public class UserBuilder
{
    private string? _name;

    public UserBuilder()
    {
    }

    public UserBuilder WithName(string? name)
    {
        _name = name;
        return this;
    }

    public User? Build()
    {
        return new User(_name);
    }
}