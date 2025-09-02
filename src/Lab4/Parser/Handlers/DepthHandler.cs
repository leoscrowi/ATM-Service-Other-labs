namespace Itmo.ObjectOrientedProgramming.Lab4.Parser.Handlers;

public class DepthHandler : ParameterHandlerBase
{
    public override string? Handle(IEnumerator<string> request)
    {
        if (request.Current is not "-d") return NextHandler?.Handle(request);

        if (request.MoveNext() is false) return null;

        string? depth = int.TryParse(request.Current, out _) ? request.Current : null;

        if (depth is null) return NextHandler?.Handle(request);
        return depth;
    }
}