using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Recipients;

public abstract class RecipientDecorator : AbstractRecipient
{
    protected IRecipient Recipient { get; set; }

    protected RecipientDecorator(IRecipient recipient)
    {
        Recipient = recipient;
    }

    public override void Filter(int? importantLevel)
    {
        Recipient.Filter(importantLevel);
    }

    public override void RecieveMessage(Message? message)
    {
        Recipient.RecieveMessage(message);
    }

    public abstract override void SendMessage();
}