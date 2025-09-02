namespace Itmo.ObjectOrientedProgramming.Lab4.Parser.Handlers;

public class FileSystemModeHandler : ParameterHandlerBase
{
    public override string? Handle(IEnumerator<string> request)
    {
        if (request.Current is not "-m")
            return NextHandler?.Handle(request);

        if (request.MoveNext() is false) return null;

        string? mode = request.Current switch
        {
            "local" => "local",
            _ => null,
        };

        if (mode is null) return NextHandler?.Handle(request);
        return mode;
    }
}