namespace Itmo.ObjectOrientedProgramming.Lab4.Parser.Handlers;

public abstract class ParameterHandlerBase : IParameterHandler
{
    protected IParameterHandler? NextHandler { get; private set; }

    public IParameterHandler AddNext(IParameterHandler handler)
    {
        if (NextHandler is null)
        {
            NextHandler = handler;
        }
        else
        {
            NextHandler.AddNext(handler);
        }

        return this;
    }

    public abstract string? Handle(IEnumerator<string> request);
}