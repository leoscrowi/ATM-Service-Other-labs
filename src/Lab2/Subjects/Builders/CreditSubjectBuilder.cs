using Itmo.ObjectOrientedProgramming.Lab2.CoupleTypes;
using Itmo.ObjectOrientedProgramming.Lab2.Users;

namespace Itmo.ObjectOrientedProgramming.Lab2.Subjects.Builders;

public class CreditSubjectBuilder : SubjectBuilderBase
{
    public override CreditSubject Build(
        string? title,
        LinkedList<Lecture>? lectures,
        LinkedList<Laboratory>? laboratories,
        int points,
        User? author)
    {
        if (author is null) throw new Exception("You must to enter the author.");
        return new CreditSubject(Guid.NewGuid(), title, lectures, laboratories, points, author, null);
    }
}