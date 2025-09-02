using Itmo.ObjectOrientedProgramming.Lab2.Repositories;
using Itmo.ObjectOrientedProgramming.Lab2.Users;

namespace Itmo.ObjectOrientedProgramming.Lab2.CoupleTypes;

public class Laboratory : CoupleTypeAbstract
{
    public string? Criteria { get; private set; }

    public int Points { get; private set; }

    public Laboratory(
        Guid identifier,
        string? title,
        string? description,
        User? author,
        string? criteria,
        int points,
        Guid? prototypeIdentifier) : base(identifier, title, description, author, prototypeIdentifier)
    {
        Criteria = criteria;
        Points = points;
        GlobalRepository.Instance().Add(identifier, this);
    }

    public void EditCriteria(string criteria, User? author)
    {
        if (author == Author) Criteria = criteria;
        else throw new Exception("You cannot change the minimal points for the credit (You are not the author)");
    }

    public Laboratory Copy()
    {
        return new Laboratory(Guid.NewGuid(), Title, Description, Author, Criteria, Points, Identifier);
    }
}