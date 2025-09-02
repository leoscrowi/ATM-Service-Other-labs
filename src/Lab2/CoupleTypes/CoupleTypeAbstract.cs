using Itmo.ObjectOrientedProgramming.Lab2.Users;

namespace Itmo.ObjectOrientedProgramming.Lab2.CoupleTypes;

public abstract class CoupleTypeAbstract
{
    public Guid Identifier { get; private set; }

    public string? Title { get; private set; }

    public string? Description { get; private set; }

    public User? Author { get; private set; }

    public Guid? PrototypeIdentifier { get; private set; }

    protected CoupleTypeAbstract(
        Guid identifier,
        string? title,
        string? description,
        User? author,
        Guid? prototypeIdentifier)
    {
        Identifier = identifier;
        Title = title;
        Description = description;
        Author = author;
        PrototypeIdentifier = prototypeIdentifier;
    }

    public void EditTitle(string title, User? author)
    {
        if (author == Author) Title = title;
        else throw new Exception("You cannot change the minimal points for the credit (You are not the author)");
    }

    public void EditDescription(string description, User? author)
    {
        if (author == Author) Description = description;
        else throw new Exception("You cannot change the minimal points for the credit (You are not the author)");
    }
}