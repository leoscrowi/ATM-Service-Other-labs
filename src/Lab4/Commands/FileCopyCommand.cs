using Itmo.ObjectOrientedProgramming.Lab4.FileSystemStructure;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class FileCopyCommand : AbstractCommand
{
    public FileCopyCommand(IFileSystem fileSystem, string oldName, string newName) : base(fileSystem)
    {
        OldName = oldName;
        NewName = newName;
    }

    public string OldName { get; }

    public string NewName { get; }

    public override void Execute()
    {
        FileSystem?.Copy(OldName, NewName);
    }
}