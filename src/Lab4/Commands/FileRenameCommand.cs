using Itmo.ObjectOrientedProgramming.Lab4.FileSystemStructure;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class FileRenameCommand : AbstractCommand
{
    public FileRenameCommand(IFileSystem fileSystem, string path, string newName) : base(fileSystem)
    {
        Path = path;
        NewName = newName;
    }

    public string Path { get; }

    public string NewName { get; }

    public override void Execute()
    {
        FileSystem?.Rename(Path, NewName);
    }
}