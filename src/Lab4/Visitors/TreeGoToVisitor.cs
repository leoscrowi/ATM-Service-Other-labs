using Itmo.ObjectOrientedProgramming.Lab4.FileSystemStructure;

namespace Itmo.ObjectOrientedProgramming.Lab4.Visitors;

public class TreeGoToVisitor : IFileSystemVisitor
{
    private int _depth;

    public string GoToPath { get; }

    public TreeGoToVisitor(string path)
    {
        GoToPath = path;
    }

    public void Visit(FileSystemComponent component)
    {
        _depth++;
        WriteTree(component.Path);
        _depth--;
    }

    public void Visit(DirectoryFileSystemComponent component)
    {
        _depth++;
        WriteTree(component.Path);
        foreach (IFileSystemComponent innerComponent in component.Components)
        {
            innerComponent.Accept(this);
        }

        _depth--;
    }

    private void WriteTree(string path)
    {
        if (path == GoToPath)
        {
            Console.Write(string.Concat(Enumerable.Repeat("    ", _depth)));
            Console.Write("|———> ");
        }
    }
}