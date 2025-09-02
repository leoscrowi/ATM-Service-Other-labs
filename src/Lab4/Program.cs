using Itmo.ObjectOrientedProgramming.Lab4.FileSystemStructure;
using Itmo.ObjectOrientedProgramming.Lab4.Parser;

namespace Itmo.ObjectOrientedProgramming.Lab4;

public class Program
{
    public static void Main()
    {
        var fileSystem = new FileSystem();
        var parser = new CommandParser(fileSystem);
        while (true)
        {
            string? line = Console.ReadLine();
            parser.ParseCommand(line);
        }
    }
}