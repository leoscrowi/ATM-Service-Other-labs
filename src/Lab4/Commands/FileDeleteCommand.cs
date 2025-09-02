using Itmo.ObjectOrientedProgramming.Lab4.FileSystemStructure;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class FileDeleteCommand : AbstractCommand
{
    public FileDeleteCommand(IFileSystem fileSystem, string path) : base(fileSystem)
    {
        Path = path;
    }

    public string Path { get; }

    public override void Execute()
    {
        FileSystem?.Delete(Path);
    }
}