using Crayon;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Displays;

public interface IDriver
{
    public void Output(Message message);

    public void Clear();

    public void SetColor(IOutput color);
}