using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystemStructure;
using Itmo.ObjectOrientedProgramming.Lab4.Parser.Handlers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parser;

public class CommandExecuter
{
    public CommandExecuter(IFileSystem fileSystem)
    {
        FileSystem = fileSystem;
    }

    public ICommand? Command { get; private set; } = null;

    public IFileSystem FileSystem { get; private set; }

    public ICommand? CreateCommand(string command, IEnumerable<string> args)
    {
        string? path;
        IParameterHandler handler;
        using IEnumerator<string> request = args.GetEnumerator();
        string sourcePath;
        string? mode = null;
        string destinationPath;
        switch (command)
        {
            case "disconnect":
                Command = new DisconnectCommand(FileSystem);
                break;

            case "connect":
                request.MoveNext();
                path = request.Current;
                handler = new FileSystemModeHandler();
                mode = null;
                while (request.MoveNext())
                {
                    mode = handler.Handle(request);
                }

                Command = new ConnectCommand(FileSystem, path, mode);
                break;

            case "tree list":
                handler = new DepthHandler();
                string? depth = null;
                while (request.MoveNext())
                {
                    depth = handler.Handle(request);
                }

                int n;
                if (int.TryParse(depth, out n)) Command = new TreeListCommand(FileSystem, n);
                else return null;
                break;

            case "tree goto":
                request.MoveNext();
                path = request.Current;
                Command = new TreeGotoCommand(FileSystem, path);
                break;

            case "file show":
                request.MoveNext();
                path = request.Current;
                handler = new FileShowHandler();
                mode = null;
                while (request.MoveNext())
                {
                    mode = handler.Handle(request);
                }

                Command = new FileShowCommand(FileSystem, path, mode);
                break;

            case "file move":
                request.MoveNext();
                sourcePath = request.Current;
                if (!request.MoveNext()) return null;
                destinationPath = request.Current;
                Command = new FileMoveCommand(FileSystem, sourcePath, destinationPath);
                break;

            case "file copy":
                request.MoveNext();
                sourcePath = request.Current;
                if (!request.MoveNext()) return null;
                destinationPath = request.Current;
                Command = new FileCopyCommand(FileSystem, sourcePath, destinationPath);
                break;

            case "file delete":
                request.MoveNext();
                path = request.Current;
                Command = new FileDeleteCommand(FileSystem, path);
                break;

            case "file rename":
                request.MoveNext();
                path = request.Current;
                if (!request.MoveNext()) return null;
                string name = request.Current;
                Command = new FileRenameCommand(FileSystem, path, name);
                break;
        }

        return Command;
    }

    public bool ExecuteCommand()
    {
        if (Command != null)
        {
            Command.Execute();
            return true;
        }
        else
        {
            return false;
        }
    }
}