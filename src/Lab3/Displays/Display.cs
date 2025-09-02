using Crayon;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Displays;

public class Display : IDisplay
{
    public Message? Message { get; private set; }

    private readonly DisplayDriver _driver = new DisplayDriver();

    public void SetColor(IOutput? color)
    {
        if (color != null) _driver.SetColor(color);
    }

    public void Output()
    {
        _driver.Clear();
        _driver.Output(Message);
    }

    public void RecieveMessage(Message? message)
    {
        Message = message;
    }
}