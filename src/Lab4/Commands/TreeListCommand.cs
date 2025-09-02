using Itmo.ObjectOrientedProgramming.Lab4.FileSystemStructure;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class TreeListCommand : AbstractCommand
{
    public int Depth { get; }

    public TreeListCommand(IFileSystem fileSystem, int depth = 1) : base(fileSystem)
    {
        Depth = depth;
    }

    public override void Execute()
    {
        FileSystem?.TreeList(Depth);
    }
}