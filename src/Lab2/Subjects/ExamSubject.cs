using Itmo.ObjectOrientedProgramming.Lab2.CoupleTypes;
using Itmo.ObjectOrientedProgramming.Lab2.Repositories;
using Itmo.ObjectOrientedProgramming.Lab2.Users;

namespace Itmo.ObjectOrientedProgramming.Lab2.Subjects;

public class ExamSubject : AbstractSubject
{
    public ExamSubject(
        Guid identifier,
        string? title,
        LinkedList<Lecture>? lectures,
        LinkedList<Laboratory>? laboratories,
        int examPoints,
        User? author,
        Guid? prototypeIdentifier) : base(identifier, title, lectures, laboratories, examPoints, author, prototypeIdentifier)
    {
        if (SummaryPoints + examPoints != 100)
        {
            throw new Exception("The summary points must be equal to 100.");
        }

        GlobalRepository.Instance().Add(identifier, this);
    }

    public override void EditSubjectPoints(int subjectPoints, User? author)
    {
        throw new Exception("Examsubject points cannot be edited.");
    }

    public override ExamSubject Clone()
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

        return new ExamSubject(Guid.NewGuid(), Title, newLections, Laboratories, SubjectPoints, Author, Identifier);
    }
}