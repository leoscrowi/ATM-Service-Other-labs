using Itmo.ObjectOrientedProgramming.Lab3.MessagesEndPoints;

namespace Itmo.ObjectOrientedProgramming.Lab3.Recipients;

public interface IRecipient : IRecieveMessages
{
    public void Filter(int? importantLevel);

    public void SendMessage();

    public void Log();
}