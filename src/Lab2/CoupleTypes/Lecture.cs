using Itmo.ObjectOrientedProgramming.Lab2.Repositories;
using Itmo.ObjectOrientedProgramming.Lab2.Users;

namespace Itmo.ObjectOrientedProgramming.Lab2.CoupleTypes;

public class Lecture : CoupleTypeAbstract
{
    public string? Content { get; private set; }

    public Lecture(
        Guid identifier,
        string? title,
        string? description,
        User? author,
        string? content,
        Guid? prototypeIdentifier) : base(identifier, title, description, author, prototypeIdentifier)
    {
        Content = content;
        GlobalRepository.Instance().Add(identifier, this);
    }

    public void EditContent(string content, User? author)
    {
        if (author == Author) Content = content;
        else throw new Exception("You cannot change the minimal points for the credit (You are not the author)");
    }

    public Lecture Copy()
    {
        return new Lecture(Guid.NewGuid(), Title, Description, Author, Content, Identifier);
    }
}