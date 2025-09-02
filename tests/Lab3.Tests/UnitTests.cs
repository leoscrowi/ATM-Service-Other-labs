using Itmo.ObjectOrientedProgramming.Lab3.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Messangers;
using Itmo.ObjectOrientedProgramming.Lab3.Recipients;
using Itmo.ObjectOrientedProgramming.Lab3.Topics;
using Itmo.ObjectOrientedProgramming.Lab3.Users;
using Moq;
using Xunit;

namespace Lab3.Tests;

public class UnitTests
{
    [Fact]
    public void UserUnreadMessageTest()
    {
        var user1 = new User("Ivan", "Ivan@gmail.com");
        var user2 = new User("Konstantin", "Konstantin@gmail.com");
        var message = new Message("Test message", "There is a body of the message", 1);
        user1.SendMessage(user2, message);
        Assert.NotEmpty(user2.GetUnreadMessages());
        Assert.Empty(user1.GetUnreadMessages());
        Assert.Empty(user2.GetReadMessages());
    }

    [Fact]
    public void MarkUnreadAsReadTest()
    {
        var user1 = new User("Ivan", "Ivan@gmail.com");
        var user2 = new User("Konstantin", "Konstantin@gmail.com");
        var message = new Message("Test message", "There is a body of the message", 1);
        user1.SendMessage(user2, message);
        user2.MarkMessageAsRead(message);
        Assert.Empty(user2.GetUnreadMessages());
        Assert.NotEmpty(user2.GetReadMessages());
    }

    [Fact]
    public void MarkReadAsReadTest()
    {
        var user1 = new User("Ivan", "Ivan@gmail.com");
        var user2 = new User("Konstantin", "Konstantin@gmail.com");
        var message = new Message("Test message", "There is a body of the message", 1);
        user1.SendMessage(user2, message);
        user2.MarkMessageAsRead(message);
        Assert.Throws<Exception>(() => user2.MarkMessageAsRead(message));
    }

    [Fact]
    public void FilterMessagesTest()
    {
        var message = new Message("Title of the message", "Body of the message", 1);
        var user = new User("Konstantin", "Konstantin@gmail.com");
        var recipient = new Mock<Recipient>(user);
        var topic = new Topic("Title of the topic", recipient.Object);
        recipient.Object.Filter(2);
        topic.SendMessage(message);
        recipient.Object.SendMessage();
        recipient.Verify(r => r.SendMessage(), Times.Once);
        Assert.Empty(user.GetAllMessages());
    }

    [Fact]
    public void LogTest()
    {
        var message = new Message("Title of the message", "Body of the message", 1);
        var user = new User("Konstantin", "Konstantin@gmail.com");
        var recipient = new Mock<Recipient>(user);
        var topic = new Topic("Title of the topic", recipient.Object);
        recipient.Object.Filter(1);
        topic.SendMessage(message);
        recipient.Object.SendMessage();
        recipient.Object.Log();
        recipient.Verify(r => r.Log(), Times.Once);
    }

    [Fact]
    public void MessangerTest()
    {
        var message = new Message("Title of the message", "Body of the message", 1);
        var mockMessanger = new Mock<IMessanger>();
        var recipient = new Recipient(mockMessanger.Object);
        var topic = new Topic("Title of the topic", recipient);
        topic.SendMessage(message);
        recipient.SendMessage();
        mockMessanger.Verify(m => m.RecieveMessage(message), Times.Once);
        mockMessanger.Object.Output();
        mockMessanger.Verify(m => m.Output(), Times.Once);
    }

    [Fact]
    public void FinalTest()
    {
        var message = new Message("Title of the message", "Body of the message", 3);
        var user = new User("Konstantin", "Konstantin@gmail.com");
        var firstRecipient = new Recipient(user);
        var secondRecipient = new Recipient(user);
        firstRecipient.RecieveMessage(message);
        secondRecipient.RecieveMessage(message);
        firstRecipient.Filter(2);
        firstRecipient.SendMessage();
        secondRecipient.SendMessage();
        Assert.Single(user.GetAllMessages());
    }
}