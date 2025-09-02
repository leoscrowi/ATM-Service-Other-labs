namespace Itmo.ObjectOrientedProgramming.Lab3.Recipients;

public class Logger
{
    private string? _logs = string.Empty;

    public Logger()
    {
    }

    public void WriteLog(string log)
    {
        _logs += log;
    }

    public void ShowLog()
    {
        Console.WriteLine(_logs);
    }
}