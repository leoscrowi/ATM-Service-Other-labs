using Itmo.ObjectOrientedProgramming.Lab4.FileSystemStructure;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class TreeGotoCommand : AbstractCommand
{
    public string Path { get; }

    public TreeGotoCommand(IFileSystem fileSystem, string path) : base(fileSystem)
    {
        Path = path;
    }

    public override void Execute()
    {
        FileSystem?.TreeGoto(Path);
    }
}