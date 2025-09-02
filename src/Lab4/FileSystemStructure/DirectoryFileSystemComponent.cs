using Itmo.ObjectOrientedProgramming.Lab4.Visitors;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystemStructure;

public class DirectoryFileSystemComponent : IFileSystemComponent
{
    public DirectoryFileSystemComponent(
        string name,
        IReadOnlyCollection<IFileSystemComponent> components,
        string path)
    {
        Name = name;
        Components = components;
        Path = path;
    }

    public string Name { get; }

    public IReadOnlyCollection<IFileSystemComponent> Components { get; }

    public string Path { get; }

    public void Accept(IFileSystemVisitor visitor)
    {
        visitor.Visit(this);
    }
}