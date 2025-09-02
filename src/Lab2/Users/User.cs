using Itmo.ObjectOrientedProgramming.Lab2.Repositories;

namespace Itmo.ObjectOrientedProgramming.Lab2.Users;

public class User
{
    public Guid Identifier { get; private set; }

    public string? Name { get; private set; }

    public User(string? name)
    {
        Name = name;
        Identifier = Guid.NewGuid();
        GlobalRepository.Instance().Add(Identifier, this);
    }
}