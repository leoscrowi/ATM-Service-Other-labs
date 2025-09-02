using Itmo.ObjectOrientedProgramming.Lab2.Subjects;
using Itmo.ObjectOrientedProgramming.Lab2.Users;

namespace Itmo.ObjectOrientedProgramming.Lab2.EducationalPrograms;

public class EducationalProgramBuilder
{
    private readonly Dictionary<int, AbstractSubject>? _subjects = new Dictionary<int, AbstractSubject>();
    private string? _title;
    private User? _director;

    public EducationalProgramBuilder WithTitle(string? title)
    {
        _title = title;
        return this;
    }

    public EducationalProgramBuilder WithSubject(int semester, AbstractSubject subject)
    {
        _subjects?.Add(semester, subject);
        return this;
    }

    public EducationalProgramBuilder WithDirector(User user)
    {
        _director = user;
        return this;
    }

    public EducationalProgram Build()
    {
        return new EducationalProgram(Guid.NewGuid(), _title, _director, _subjects);
    }
}