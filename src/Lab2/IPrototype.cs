namespace Itmo.ObjectOrientedProgramming.Lab2;

public interface IPrototype<T> where T : IPrototype<T>
{
    public T Clone();
}