namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystemStructure;

public interface IFileSystem
{
    public void Connect(string path, string? mode = "local");

    public void Disconnect();

    public void Delete(string path);

    public void Rename(string sourcePath, string name);

    public void Copy(string sourcePath, string destinationPath);

    public void Move(string sourcePath, string destinationPath);

    public void ShowFile(string path, string? mode = "console");

    public void TreeGoto(string path);

    public void TreeList(int depth = 1);
}