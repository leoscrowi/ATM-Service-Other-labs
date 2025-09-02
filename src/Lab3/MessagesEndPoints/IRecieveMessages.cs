using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.MessagesEndPoints;

public interface IRecieveMessages
{
    public void RecieveMessage(Message? message);
}