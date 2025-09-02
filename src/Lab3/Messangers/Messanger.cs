using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Messangers;

public class Messanger : IMessanger
{
    public Message? Message { get; private set; }

    public void Output()
    {
        Console.WriteLine("Месседжер:");
        Console.WriteLine(Message);
    }

    public void RecieveMessage(Message? message)
    {
        Message = message;
    }
}