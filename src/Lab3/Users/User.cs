using Itmo.ObjectOrientedProgramming.Lab3.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.MessagesEndPoints;

namespace Itmo.ObjectOrientedProgramming.Lab3.Users;

public class User : IRecieveMessages
{
    public Dictionary<bool, LinkedList<Message>> Messages { get; private set; } = new Dictionary<bool, LinkedList<Message>>();

    public string? Name { get; private set; }

    public string? Email { get; private set; }

    public User(string? name, string? email)
    {
        Name = name;
        Email = email;
        Messages[false] = new LinkedList<Message>();
        Messages[true] = new LinkedList<Message>();
    }

    public LinkedList<Message> GetAllMessages()
    {
        var messages = new LinkedList<Message>();
        foreach (Message message in Messages[false])
        {
            messages.AddLast(message);
        }

        foreach (Message message in Messages[true])
        {
            messages.AddLast(message);
        }

        return messages;
    }

    public void SendMessage(User user, Message message)
    {
        user.RecieveMessage(message);
    }

    public void RecieveMessage(Message? message)
    {
        if (message != null) Messages[false].AddLast(message);
    }

    public LinkedList<Message> GetUnreadMessages()
    {
        return Messages[false];
    }

    public LinkedList<Message> GetReadMessages()
    {
        return Messages[true];
    }

    public void MarkMessageAsRead(Message message)
    {
        foreach (Message item in Messages[false])
        {
            if (item == message)
            {
                Messages[false].Remove(item);
                Messages[true].AddLast(item);
                return;
            }
        }

        throw new Exception("Message not found");
    }
}