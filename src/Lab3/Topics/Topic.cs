using Itmo.ObjectOrientedProgramming.Lab3.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Recipients;

namespace Itmo.ObjectOrientedProgramming.Lab3.Topics;

public class Topic
{
    public string Title { get; private set; }

    public LinkedList<IRecipient> Recipients { get; private set; }

    public Topic(string title, LinkedList<IRecipient> recipient)
    {
        Title = title;
        Recipients = recipient;
    }

    public Topic(string title, IRecipient recipient)
    {
        Title = title;
        Recipients = new LinkedList<IRecipient>();
        Recipients.AddLast(recipient);
    }

    public void AddRecipient(IRecipient recipient)
    {
        Recipients.AddLast(recipient);
    }

    public void SendMessage(Message message)
    {
        foreach (IRecipient recipient in Recipients)
        {
            recipient.RecieveMessage(message);
        }
    }
}