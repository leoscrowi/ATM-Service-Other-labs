using Itmo.ObjectOrientedProgramming.Lab4.FileSystemStructure;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class ConnectCommand : AbstractCommand
{
    public string Address { get; } = string.Empty;

    public string? Mode { get; } = null;

    public ConnectCommand(IFileSystem fileSystem, string address, string? mode = "console") : base(fileSystem)
    {
        Address = address;
        Mode = mode;
    }

    public override void Execute()
    {
        FileSystem?.Connect(Address, Mode);
    }
}