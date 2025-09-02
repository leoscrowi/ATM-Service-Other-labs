using Itmo.ObjectOrientedProgramming.Lab2.CoupleTypes;
using Itmo.ObjectOrientedProgramming.Lab2.Repositories;
using Itmo.ObjectOrientedProgramming.Lab2.Users;

namespace Itmo.ObjectOrientedProgramming.Lab2.Subjects;

public class CreditSubject : AbstractSubject
{
    public CreditSubject(
        Guid identifier,
        string? title,
        LinkedList<Lecture>? lectures,
        LinkedList<Laboratory>? laboratories,
        int minimalPoints,
        User? author,
        Guid? prototypeIdentifier) : base(identifier, title, lectures, laboratories, minimalPoints, author, prototypeIdentifier)
    {
        if (SummaryPoints != 100)
        {
            throw new Exception("The summary points must be equal to 100.");
        }

        GlobalRepository.Instance().Add(identifier, this);
    }

    public override CreditSubject Clone()
    {
        var newLections = new LinkedList<Lecture>();
        if (Lectures is not null)
        {
            foreach (Lecture lecture in Lectures)
            {
                Lecture copuiedLecture = lecture.Copy();
                newLections.AddLast(copuiedLecture);
            }
        }

        return new CreditSubject(Guid.NewGuid(), Title, newLections, Laboratories, SubjectPoints, Author, Identifier);
    }
}