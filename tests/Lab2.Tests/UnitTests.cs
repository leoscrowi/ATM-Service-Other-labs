using Itmo.ObjectOrientedProgramming.Lab2.CoupleTypes;
using Itmo.ObjectOrientedProgramming.Lab2.CoupleTypes.Builders;
using Itmo.ObjectOrientedProgramming.Lab2.Subjects;
using Itmo.ObjectOrientedProgramming.Lab2.Subjects.Builders;
using Itmo.ObjectOrientedProgramming.Lab2.Users;
using Itmo.ObjectOrientedProgramming.Lab2.Users.Builders;
using Xunit;

namespace Lab2.Tests;

public class UnitTests
{
    [Fact]
    public void EditSuccesfulTest()
    {
        var userBuilder = new UserBuilder();
        User? user = userBuilder.WithName("Иван Алексеевич").Build();
        Lecture lecture = new LectureBuilder()
            .WithTitle("Лекция №1")
            .WithAuthor(user)
            .WithDescription("Лекция номер один по ООП")
            .WithContent("Лекция пока пуста")
            .Build();
        lecture.EditTitle("Лекция 1", user);
        Assert.Equal("Лекция 1", lecture.Title);
    }

    [Fact]
    public void EditErrorTest()
    {
        var userBuilder = new UserBuilder();
        User? user1 = userBuilder.WithName("Иван Алексеевич").Build();
        User? user2 = userBuilder.WithName("Николай Андреевич").Build();
        Lecture lecture = new LectureBuilder()
            .WithTitle("Лекция №1")
            .WithAuthor(user1)
            .WithDescription("Лекция номер один по ООП")
            .WithContent("Лекция пока пуста")
            .Build();
        Assert.Throws<Exception>(() => lecture.EditTitle("Лекция 1", user2));
    }

    [Fact]
    public void CopyTest()
    {
        var userBuilder = new UserBuilder();
        User? user1 = userBuilder.WithName("Иван Алексеевич").Build();
        Lecture lecture = new LectureBuilder()
            .WithTitle("Лекция №1")
            .WithAuthor(user1)
            .WithDescription("Лекция номер один по ООП")
            .WithContent("Лекция пока пуста")
            .Build();
        Lecture lectureCopy = lecture.Copy();
        Assert.Equal(lecture.Identifier, lectureCopy.PrototypeIdentifier);
    }

    [Fact]
    public void CreditSucessfulTest()
    {
        var userBuilder = new UserBuilder();
        User? user1 = userBuilder.WithName("Иван Алексеевич").Build();
        Lecture lecture = new LectureBuilder()
            .WithTitle("Лекция №1")
            .WithAuthor(user1)
            .WithDescription("Лекция номер один по ООП")
            .WithContent("Лекция пока пуста")
            .Build();
        Laboratory firstLaboratory =
            new LaboratoryBuilder()
                .WithTitle("Лабораторная 1")
                .WithAuthor(user1)
                .WithPoints(20)
                .Build();
        Laboratory secondLaboratory =
            new LaboratoryBuilder()
                .WithTitle("Лабораторная 2")
                .WithAuthor(user1)
                .WithPoints(80)
                .Build();
        AbstractSubject creditSubject = new CreditSubjectBuilder().WithTitle("Объектно Ориентированное Программирование")
            .WithAuthor(user1)
            .WithLaboratory(firstLaboratory)
            .WithLaboratory(secondLaboratory)
            .Build();
    }

    [Fact]
    public void CreditErrorTest()
    {
        var userBuilder = new UserBuilder();
        User? user1 = userBuilder.WithName("Иван Алексеевич").Build();
        Lecture lecture = new LectureBuilder()
            .WithTitle("Лекция №1")
            .WithAuthor(user1)
            .WithDescription("Лекция номер один по ООП")
            .WithContent("Лекция пока пуста")
            .Build();
        Laboratory firstLaboratory =
            new LaboratoryBuilder()
                .WithTitle("Лабораторная 1")
                .WithAuthor(user1)
                .WithPoints(20)
                .Build();
        Laboratory secondLaboratory =
            new LaboratoryBuilder()
                .WithTitle("Лабораторная 2")
                .WithAuthor(user1)
                .WithPoints(10)
                .Build();
        Assert.Throws<Exception>(() => new CreditSubjectBuilder().WithTitle("Объектно Ориентированное Программирование")
            .WithAuthor(user1)
            .WithLaboratory(firstLaboratory)
            .WithLaboratory(secondLaboratory)
            .Build());
    }

    [Fact]
    public void ExamSucessfulTest()
    {
        var userBuilder = new UserBuilder();
        User? user1 = userBuilder.WithName("Иван Алексеевич").Build();
        Lecture lecture = new LectureBuilder()
            .WithTitle("Лекция №1")
            .WithAuthor(user1)
            .WithDescription("Лекция номер один по ООП")
            .WithContent("Лекция пока пуста")
            .Build();
        Laboratory firstLaboratory =
            new LaboratoryBuilder()
                .WithTitle("Лабораторная 1")
                .WithAuthor(user1)
                .WithPoints(10)
                .Build();
        Laboratory secondLaboratory =
            new LaboratoryBuilder()
                .WithTitle("Лабораторная 2")
                .WithAuthor(user1)
                .WithPoints(80)
                .Build();
        AbstractSubject creditSubject = new ExamSubjectBuilder().WithTitle("Объектно Ориентированное Программирование")
            .WithAuthor(user1)
            .WithLaboratory(firstLaboratory)
            .WithLaboratory(secondLaboratory)
            .WithPoints(10)
            .Build();
    }

    [Fact]
    public void ExamErrorTest()
    {
        var userBuilder = new UserBuilder();
        User? user1 = userBuilder.WithName("Иван Алексеевич").Build();
        Lecture lecture = new LectureBuilder()
            .WithTitle("Лекция №1")
            .WithAuthor(user1)
            .WithDescription("Лекция номер один по ООП")
            .WithContent("Лекция пока пуста")
            .Build();
        Laboratory firstLaboratory =
            new LaboratoryBuilder()
                .WithTitle("Лабораторная 1")
                .WithAuthor(user1)
                .WithPoints(20)
                .Build();
        Laboratory secondLaboratory =
            new LaboratoryBuilder()
                .WithTitle("Лабораторная 2")
                .WithAuthor(user1)
                .WithPoints(80)
                .Build();
        Assert.Throws<Exception>(() => new ExamSubjectBuilder().WithTitle("Объектно Ориентированное Программирование")
            .WithAuthor(user1)
            .WithLaboratory(firstLaboratory)
            .WithLaboratory(secondLaboratory)
            .WithPoints(10)
            .Build());
    }
}