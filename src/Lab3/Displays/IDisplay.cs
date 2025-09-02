using Crayon;
using Itmo.ObjectOrientedProgramming.Lab3.MessagesEndPoints;

namespace Itmo.ObjectOrientedProgramming.Lab3.Displays;

public interface IDisplay : IRecieveMessages
{
    public void SetColor(IOutput? color);

    public void Output();
}