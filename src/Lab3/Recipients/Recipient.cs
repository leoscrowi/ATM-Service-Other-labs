using Itmo.ObjectOrientedProgramming.Lab3.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.MessagesEndPoints;

namespace Itmo.ObjectOrientedProgramming.Lab3.Recipients;

public class Recipient : AbstractRecipient
{
    public IRecieveMessages EndOfMessage { get; private set; }

    public Recipient(IRecieveMessages endOfMessage)
    {
        EndOfMessage = endOfMessage;
    }

    public override void Filter(int? importantLevel)
    {
        ImportantLevel = importantLevel;
    }

    public override void RecieveMessage(Message? message)
    {
        Message = message;
        Logger.WriteLog("Message received\n");
    }

    public override void SendMessage()
    {
        if (ImportantLevel == null || ImportantLevel >= Message?.ImportantLevel) EndOfMessage.RecieveMessage(Message);
    }

    public override void Log()
    {
        Logger.ShowLog();
    }
}