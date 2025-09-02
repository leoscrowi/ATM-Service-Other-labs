using Itmo.ObjectOrientedProgramming.Lab4.FileSystemStructure;

namespace Itmo.ObjectOrientedProgramming.Lab4.Visitors;

public class TreeVisitor : IFileSystemVisitor
{
    private int _depth;

    public int FinalDepth { get; }

    public string FileSymbols { get; }

    public string DirectorySymbols { get; }

    public string ComponentPointers { get; }

    public TreeVisitor(int finalDepth, string fileSymbols = "", string directorySymbols = "", string componentPointers = "|———> ")
    {
        FinalDepth = finalDepth;
        FileSymbols = fileSymbols;
        DirectorySymbols = directorySymbols;
        ComponentPointers = componentPointers;
    }

    public void Visit(FileSystemComponent component)
    {
        _depth++;
        WriteTree(FileSymbols + component.Name);
        _depth--;
    }

    public void Visit(DirectoryFileSystemComponent component)
    {
        _depth++;
        WriteTree(DirectorySymbols + component.Name);
        if (_depth <= FinalDepth)
        {
            foreach (IFileSystemComponent innerComponent in component.Components)
            {
                innerComponent.Accept(this);
            }
        }

        _depth--;
    }

    private void WriteTree(string name)
    {
        if (_depth is not 0)
        {
            Console.Write(string.Concat(Enumerable.Repeat("    ", _depth)));
            Console.Write("|———> ");
        }

        Console.WriteLine(name);
    }
}