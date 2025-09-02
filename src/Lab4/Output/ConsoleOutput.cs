namespace Itmo.ObjectOrientedProgramming.Lab4.Output;

public class ConsoleOutput : IOutput
{
    public void Output(string? text)
    {
        System.Console.WriteLine(text);
    }
}