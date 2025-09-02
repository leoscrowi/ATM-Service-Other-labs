using Itmo.ObjectOrientedProgramming.Lab2.CoupleTypes;
using Itmo.ObjectOrientedProgramming.Lab2.Users;

namespace Itmo.ObjectOrientedProgramming.Lab2.Subjects;

public abstract class AbstractSubject : IPrototype<AbstractSubject>
{
    public Guid Identifier { get; private set; }

    public User? Author { get; private set; }

    public string? Title { get; private set; }

    public LinkedList<Laboratory>? Laboratories { get; private set; }

    public LinkedList<Lecture>? Lectures { get; private set; }

    public int SummaryPoints { get; protected set; } = 0;

    public int SubjectPoints { get; private set; }

    public Guid? PrototypeIdentifier { get; private set; }

    protected AbstractSubject(
        Guid identifier,
        string? title,
        LinkedList<Lecture>? lectures,
        LinkedList<Laboratory>? laboratories,
        int subjectPoints,
        User? author,
        Guid? prototypeIdentifier)
    {
        Identifier = identifier;
        Title = title;
        Laboratories = laboratories;
        Lectures = lectures;
        SubjectPoints = subjectPoints;
        Author = author;
        PrototypeIdentifier = prototypeIdentifier;

        if (Laboratories != null)
        {
            foreach (Laboratory laboratory in Laboratories)
            {
                Console.WriteLine("Hello");
                SummaryPoints += laboratory.Points;
            }
        }
    }

    public void EditTitle(string title, User? author)
    {
        if (author == Author) Title = title;
        else throw new ArgumentException("You cannot change the name of subject (You are not the author)");
    }

    public void EditLections(LinkedList<Lecture> lectures, User? author)
    {
        if (author == Author) Lectures = lectures;
        else throw new ArgumentException("You cannot change the list of lections (You are not the author)");
    }

    public virtual void EditSubjectPoints(int subjectPoints, User? author)
    {
        if (author == Author) SubjectPoints = subjectPoints;
        else throw new Exception("You cannot change the number of points (You are not the author)");
    }

    public abstract AbstractSubject Clone();
}