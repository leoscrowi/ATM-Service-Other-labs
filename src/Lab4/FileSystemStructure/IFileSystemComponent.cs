using Itmo.ObjectOrientedProgramming.Lab4.Visitors;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystemStructure;

public interface IFileSystemComponent
{
    string Name { get; }

    void Accept(IFileSystemVisitor visitor);
}