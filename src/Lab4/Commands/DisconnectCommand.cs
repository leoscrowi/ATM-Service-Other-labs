using Itmo.ObjectOrientedProgramming.Lab4.FileSystemStructure;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class DisconnectCommand : AbstractCommand
{
    public DisconnectCommand(IFileSystem fileSystem) : base(fileSystem)
    {
    }

    public override void Execute()
    {
        FileSystem?.Disconnect();
    }
}