namespace Itmo.ObjectOrientedProgramming.Lab3.Recipients;

public class GroupRecipient : RecipientDecorator
{
    public LinkedList<IRecipient> Recipients { get; private set; } = new LinkedList<IRecipient>();

    public GroupRecipient(IRecipient recipient) : base(recipient)
    {
    }

    public override void SendMessage()
    {
        Recipient.SendMessage();
        foreach (IRecipient recipient in Recipients)
        {
            recipient.SendMessage();
        }
    }

    public override void Log()
    {
        Recipient.Log();
    }

    public void AddRecipient(IRecipient recipient)
    {
        Recipients.AddLast(recipient);
    }
}