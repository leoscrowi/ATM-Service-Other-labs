using Itmo.ObjectOrientedProgramming.Lab4.Output;
using Itmo.ObjectOrientedProgramming.Lab4.Visitors;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystemStructure;

public class FileSystem : IFileSystem
{
    private readonly FileSystemComponentFactory _componentFactory = new FileSystemComponentFactory();

    private readonly Dictionary<string, IOutput?> _modes = new Dictionary<string, IOutput?>()
    {
        { "-d", new ConsoleOutput() },
        { string.Empty, null },
    };

    public IFileSystemComponent? RootDirectory { get; private set; } = null;

    public string AbsolutePath { get; private set;  } = string.Empty;

    public IOutput? Output { get; private set; } = new ConsoleOutput();

    public bool Connected { get; private set; } = false;

    public FileSystem() { }

    public void Connect(string path, string? mode = "local")
    {
        System.Console.WriteLine($"Connecting to {path}");
        if (mode == null)
        {
            Output?.Output("Can't find mode");
            return;
        }

        if (!Connected)
        {
            AbsolutePath = path;
            if (File.Exists(path)) throw new Exception("You can't connect to a file, path must to point to a directory");
            RootDirectory = _componentFactory.CreateComponent(path);
            Connected = true;
            Output?.Output("Connected");
        }
        else
        {
            Output?.Output("You already connected. Use <tree goto>");
        }
    }

    public void Disconnect()
    {
        AbsolutePath = string.Empty;
        RootDirectory = null;
        Connected = false;
        Output?.Output("Disconnected");
    }

    public void Delete(string path)
    {
        if (Connected)
        {
            if (File.Exists(GetRelativePath(path)))
            {
                System.IO.File.Delete(GetRelativePath(path));
                Output?.Output($"File {path} deleted");
            }
            else
            {
                Output?.Output($"Can't find file {path}");
            }
        }
        else
        {
            Output?.Output($"You are not connected");
        }
    }

    public void Rename(string sourcePath, string name)
    {
        if (Connected)
        {
            if (File.Exists(GetRelativePath(sourcePath)))
            {
                System.IO.File.Copy(
                    GetRelativePath(sourcePath),
                    Path.GetDirectoryName(GetRelativePath(sourcePath)) + @"\" + name);
                Delete(GetRelativePath(sourcePath));
                Output?.Output($"File renamed to {name}");
            }
            else
            {
                Output?.Output($"Can't find file: {name}");
            }
        }
        else
        {
            Output?.Output($"You are not connected");
        }
    }

    public void Copy(string sourcePath, string destinationPath)
    {
        if (Connected)
        {
            if (File.Exists(GetRelativePath(sourcePath)) && Directory.Exists(GetRelativePath(destinationPath)))
            {
                System.IO.File.Copy(
                    GetRelativePath(sourcePath),
                    Path.Combine(GetRelativePath(destinationPath), Path.GetFileName(GetRelativePath(sourcePath))));
                Output?.Output($"File {sourcePath} copied to {destinationPath}");
            }
            else
            {
                Output?.Output($"File {sourcePath} not found");
            }
        }
        else
        {
            Output?.Output($"You are not connected");
        }
    }

    public void Move(string sourcePath, string destinationPath)
    {
        if (Connected)
        {
            if (System.IO.File.Exists(GetRelativePath(sourcePath)) && System.IO.Directory.Exists(GetRelativePath(destinationPath)))
            {
                System.IO.File.Move(
                    GetRelativePath(sourcePath),
                    Path.Combine(GetRelativePath(destinationPath), Path.GetFileName(GetRelativePath(sourcePath))));
                Output?.Output($"File {sourcePath} moved to {destinationPath}");
            }
            else
            {
                Output?.Output($"File not found, check if directories are correct");
            }
        }
        else
        {
            Output?.Output($"You are not connected");
        }
    }

    public void ShowFile(string path, string? mode = "-m")
    {
        if (Connected)
        {
            if (mode != null) SwitchMode(mode);
            string? line;
            try
            {
                var sr = new StreamReader(GetRelativePath(path));
                line = sr.ReadLine();
                while (line != null)
                {
                    Output?.Output(line);
                    line = sr.ReadLine();
                }

                sr.Close();
                Output?.Output(line);
            }
            catch (Exception)
            {
                Output?.Output("Can't read the file");
            }
        }
        else
        {
            Output?.Output($"You are not connected");
        }
    }

    public void TreeGoto(string path)
    {
        if (Connected)
        {
            if (File.Exists(GetRelativePath(path)))
            {
                Output?.Output("You can't connect to directory");
            }
            else
            {
                AbsolutePath = path;
                RootDirectory = _componentFactory.CreateComponent(path);
            }
        }
        else
        {
            Output?.Output("You must to use command <connect>");
        }
    }

    public void TreeList(int depth = 1)
    {
        if (Connected)
        {
            var visitor = new TreeVisitor(depth, directorySymbols: @"\");
            RootDirectory?.Accept(visitor);
        }
        else
        {
            Output?.Output("You must be connected to a directory");
        }
    }

    private string GetRelativePath(string relativePath)
    {
        if (Path.Exists(Path.Combine(AbsolutePath, relativePath)))
        {
            return Path.Combine(AbsolutePath, relativePath);
        }
        else
        {
            Console.WriteLine("relative path: " + relativePath);
            return relativePath;
        }
    }

    private void SwitchMode(string mode)
    {
        Output = _modes[mode];
    }
}