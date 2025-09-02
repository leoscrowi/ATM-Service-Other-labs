using Itmo.ObjectOrientedProgramming.Lab4.FileSystemStructure;
using System.Diagnostics;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parser;

public class CommandParser
{
    private readonly SortedSet<string> _commands = new SortedSet<string>()
    {
        "disconnect",
        "connect",
        "tree goto",
        "tree list",
        "file show",
        "file move",
        "file copy",
        "file delete",
        "file rename",
    };

    public CommandParser(IFileSystem fileSystem)
    {
        FileSystem = fileSystem;
        if (FileSystem != null) Executer = new CommandExecuter(fileSystem);
    }

    public IFileSystem? FileSystem { get; }

    public CommandExecuter? Executer { get; }

    public void ParseCommand(string? inputString)
    {
        if (inputString != null)
        {
            string[] tokens = inputString.Split(' ');
            string command = tokens.ToList()[0].Trim();
            int ind = 1;
            while (!_commands.Contains(command) && ind < tokens.Length - 1)
            {
                command = command + ' ' + tokens[ind].Trim();
                ind++;
            }

            if (_commands.Contains(command))
            {
                IEnumerable<string> args = tokens.Skip(ind).ToArray();
                Executer?.CreateCommand(command, args);
                Debug.Assert(Executer != null, nameof(Executer) + " != null");
                if (!Executer.ExecuteCommand()) Console.WriteLine("Can't parse command");
            }
        }
    }
}