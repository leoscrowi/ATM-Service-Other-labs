using Itmo.ObjectOrientedProgramming.Lab2.CoupleTypes;
using Itmo.ObjectOrientedProgramming.Lab2.Users;

namespace Itmo.ObjectOrientedProgramming.Lab2.Subjects.Builders;

public abstract class SubjectBuilderBase
{
    private string? _title;
    private LinkedList<Lecture>? _lectures = new LinkedList<Lecture>();
    private LinkedList<Laboratory>? _laboratories = new LinkedList<Laboratory>();
    private User? _author;
    private int _points = 0;

    public SubjectBuilderBase WithTitle(string? title)
    {
        _title = title;
        return this;
    }

    public SubjectBuilderBase WithLectures(LinkedList<Lecture>? lectures)
    {
        _lectures = lectures;
        return this;
    }

    public SubjectBuilderBase WithLection(Lecture lection)
    {
        _lectures?.AddLast(lection);
        return this;
    }

    public SubjectBuilderBase WithLaboratory(Laboratory laboratory)
    {
        _laboratories?.AddLast(laboratory);
        return this;
    }

    public SubjectBuilderBase WithLaboratories(LinkedList<Laboratory>? laboratories)
    {
        _laboratories = laboratories;
        return this;
    }

    public SubjectBuilderBase WithAuthor(User? author)
    {
        _author = author;
        return this;
    }

    public SubjectBuilderBase WithPoints(int points)
    {
        _points = points;
        return this;
    }

    public AbstractSubject Build()
    {
        return Build(_title, _lectures, _laboratories, _points, _author);
    }

    public abstract AbstractSubject Build(
        string? title,
        LinkedList<Lecture>? lectures,
        LinkedList<Laboratory>? laboratories,
        int points,
        User? author);
}