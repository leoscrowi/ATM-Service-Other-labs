using Itmo.ObjectOrientedProgramming.Lab3.Recipients;

namespace Itmo.ObjectOrientedProgramming.Lab3.Topics;

public class TopicBuilder
{
    private string? _title;
    private LinkedList<IRecipient>? _recipients;

    public TopicBuilder WithTitle(string title)
    {
        _title = title;
        return this;
    }

    public TopicBuilder WithRecipients(LinkedList<IRecipient> recipients)
    {
        _recipients = recipients;
        return this;
    }

    public Topic Build()
    {
        return new Topic(
            _title ?? throw new ArgumentNullException(),
            _recipients ?? throw new ArgumentNullException());
    }
}