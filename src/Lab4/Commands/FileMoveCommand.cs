using Itmo.ObjectOrientedProgramming.Lab4.FileSystemStructure;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class FileMoveCommand : AbstractCommand
{
    public string SourcePath { get; }

    public string DestinationPath { get; }

    public FileMoveCommand(IFileSystem fileSystem, string sourcePath, string destinationPath) : base(fileSystem)
    {
        SourcePath = sourcePath;
        DestinationPath = destinationPath;
    }

    public override void Execute()
    {
        FileSystem?.Move(SourcePath, DestinationPath);
    }
}