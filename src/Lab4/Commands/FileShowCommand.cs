using Itmo.ObjectOrientedProgramming.Lab4.FileSystemStructure;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class FileShowCommand : AbstractCommand
{
    public string Path { get; }

    public string? Mode { get; }

    public FileShowCommand(IFileSystem fileSystem, string path, string? mode = null) : base(fileSystem)
    {
        Path = path;
        Mode = mode;
    }

    public override void Execute()
    {
        FileSystem?.ShowFile(Path, Mode);
    }
}