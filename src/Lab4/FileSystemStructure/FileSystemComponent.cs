using Itmo.ObjectOrientedProgramming.Lab4.Visitors;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystemStructure;

public class FileSystemComponent : IFileSystemComponent
{
    public FileSystemComponent(string name, string path)
    {
        Name = name;
        Path = path;
    }

    public string Name { get; }

    public string Path { get; }

    public void Accept(IFileSystemVisitor visitor)
    {
        visitor.Visit(this);
    }
}