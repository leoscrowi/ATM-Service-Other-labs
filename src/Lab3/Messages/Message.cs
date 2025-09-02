namespace Itmo.ObjectOrientedProgramming.Lab3.Messages;

public class Message
{
    public Message(string title, string body, int importantLevel)
    {
        Title = title;
        Body = body;
        ImportantLevel = importantLevel;
    }

    public string? Title { get; private set; }

    public string? Body { get; private set; }

    public int ImportantLevel { get; private set; }

    public override string ToString()
    {
        return Body ?? string.Empty;
    }
}