using Itmo.ObjectOrientedProgramming.Lab4.FileSystemStructure;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public abstract class AbstractCommand : ICommand
{
    protected AbstractCommand(IFileSystem fileSystem)
    {
        FileSystem = fileSystem;
    }

    protected IFileSystem FileSystem { get; }

    public abstract void Execute();
}