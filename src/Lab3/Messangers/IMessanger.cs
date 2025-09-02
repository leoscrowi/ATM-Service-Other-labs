using Itmo.ObjectOrientedProgramming.Lab3.MessagesEndPoints;

namespace Itmo.ObjectOrientedProgramming.Lab3.Messangers;

public interface IMessanger : IRecieveMessages
{
    public void Output();
}