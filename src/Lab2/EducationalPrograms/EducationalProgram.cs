using Itmo.ObjectOrientedProgramming.Lab2.Repositories;
using Itmo.ObjectOrientedProgramming.Lab2.Subjects;
using Itmo.ObjectOrientedProgramming.Lab2.Users;

namespace Itmo.ObjectOrientedProgramming.Lab2.EducationalPrograms;

public class EducationalProgram
{
    public string? Title { get; private set; }

    public User? Director { get; private set; }

    public Dictionary<int, AbstractSubject>? Subjects { get; private set; }

    public Guid Identifier { get; private set; }

    protected internal EducationalProgram(Guid identifier, string? title, User? director, Dictionary<int, AbstractSubject>? subjects)
    {
        Identifier = identifier;
        Title = title;
        Director = director;
        Subjects = subjects;
        GlobalRepository.Instance().Add(identifier, this);
    }
}