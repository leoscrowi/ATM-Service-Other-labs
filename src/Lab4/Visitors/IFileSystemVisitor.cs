using Itmo.ObjectOrientedProgramming.Lab4.FileSystemStructure;

namespace Itmo.ObjectOrientedProgramming.Lab4.Visitors;

public interface IFileSystemVisitor
{
    void Visit(FileSystemComponent component);

    void Visit(DirectoryFileSystemComponent component);
}