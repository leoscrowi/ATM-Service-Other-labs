namespace Itmo.ObjectOrientedProgramming.Lab4.Parser.Handlers;

public class FileShowHandler : ParameterHandlerBase
{
    public override string? Handle(IEnumerator<string> request)
    {
        if (request.Current is not "-m")
            return NextHandler?.Handle(request);

        if (request.MoveNext() is false) return null;

        string? mode = request.Current switch
        {
            "console" => "console",
            _ => null,
        };

        if (mode is null) return NextHandler?.Handle(request);
        return mode;
    }
}