using Itmo.ObjectOrientedProgramming.Lab2.Users;

namespace Itmo.ObjectOrientedProgramming.Lab2.CoupleTypes.Builders;

public class LaboratoryBuilder
{
    private string? _criteria;
    private int _points;
    private string? _title;
    private string? _description;
    private User? _author;

    public LaboratoryBuilder WithTitle(string title)
    {
        _title = title;
        return this;
    }

    public LaboratoryBuilder WithDescription(string description)
    {
        _description = description;
        return this;
    }

    public LaboratoryBuilder WithAuthor(User? author)
    {
        _author = author;
        return this;
    }

    public LaboratoryBuilder WithPoints(int points)
    {
        _points = points;
        return this;
    }

    public LaboratoryBuilder WithCriteria(string criteria)
    {
        _criteria = criteria;
        return this;
    }

    public Laboratory Build()
    {
        if (_author is null) throw new Exception("You must to enter the author.");
        return new Laboratory(Guid.NewGuid(), _title, _description, _author, _criteria, _points, null);
    }
}