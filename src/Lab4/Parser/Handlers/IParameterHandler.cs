namespace Itmo.ObjectOrientedProgramming.Lab4.Parser.Handlers;

public interface IParameterHandler
{
    IParameterHandler AddNext(IParameterHandler handler);

    string? Handle(IEnumerator<string> request);
}