namespace Itmo.ObjectOrientedProgramming.Lab3.Messages;

public class MessageBuilder
{
    private string? _title;
    private string? _body;
    private int _importantLevel;

    public MessageBuilder WithTitle(string title)
    {
        _title = title;
        return this;
    }

    public MessageBuilder WithBody(string body)
    {
        _body = body;
        return this;
    }

    public MessageBuilder WithImportantLevel(int importantLevel)
    {
        _importantLevel = importantLevel;
        return this;
    }

    public Message Build()
    {
        return new Message(
            _title ?? throw new ArgumentNullException(),
            _body ?? throw new ArgumentNullException(),
            _importantLevel);
    }
}