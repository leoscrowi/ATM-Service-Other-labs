using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Recipients;

public abstract class AbstractRecipient : IRecipient
{
    public Message? Message { get; set; }

    public Logger Logger { get; private set; } = new Logger();

    protected int? ImportantLevel { get; set; } = null;

    public abstract void Filter(int? importantLevel);

    public abstract void RecieveMessage(Message? message);

    public abstract void SendMessage();

    public abstract void Log();
}