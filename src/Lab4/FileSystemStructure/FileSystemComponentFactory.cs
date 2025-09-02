namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystemStructure;

public class FileSystemComponentFactory
{
    public IFileSystemComponent CreateComponent(string path)
    {
        if (Directory.Exists(path))
        {
            string? name = Path.GetFileName(path);

            IEnumerable<string> names = Directory
                .EnumerateFileSystemEntries(path)
                .Select(Path.GetFileName)
                .Where(x => x is not null)
                .Cast<string>();

            IFileSystemComponent[] components = names
                .Select(entry => Path.Combine(path, entry))
                .Select(CreateComponent)
                .ToArray();
            return new DirectoryFileSystemComponent(name, components, path);
        }

        if (Path.Exists(path))
        {
            string name = Path.GetFileName(path);
            return new FileSystemComponent(name, path);
        }

        throw new InvalidOperationException($"File system component at {path} is not found");
    }
}