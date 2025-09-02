using Crayon;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Displays;

public class DisplayDriver : IDriver
{
    public IOutput? Color { get; private set; }

    public void Output(Message? message)
    {
        if (Color == null) Console.WriteLine(message);
        else if (message != null) Console.WriteLine(Color.Text(message.ToString()));
    }

    public void Clear()
    {
        Console.Clear();
    }

    public void SetColor(IOutput color)
    {
        Color = color;
    }
}