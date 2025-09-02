using Itmo.ObjectOrientedProgramming.Lab2.Users;

namespace Itmo.ObjectOrientedProgramming.Lab2.CoupleTypes.Builders;

public class LectureBuilder
{
    private string? _title;
    private string? _description;
    private User? _author;
    private string? _content;

    public LectureBuilder WithContent(string? content)
    {
        _content = content;
        return this;
    }

    public LectureBuilder WithTitle(string title)
    {
        _title = title;
        return this;
    }

    public LectureBuilder WithDescription(string description)
    {
        _description = description;
        return this;
    }

    public LectureBuilder WithAuthor(User? author)
    {
        _author = author;
        return this;
    }

    public Lecture Build()
    {
        if (_author is null) throw new Exception("You must to enter the author.");
        return new Lecture(Guid.NewGuid(), _title, _description, _author, _content, null);
    }
}