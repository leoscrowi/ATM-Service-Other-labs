using Itmo.ObjectOrientedProgramming.Lab4.FileSystemStructure;
using Itmo.ObjectOrientedProgramming.Lab4.Parser;
using Moq;
using Xunit;

namespace Lab4.Tests;

public class UnitTests
{
    [Fact]
    public void TestConnect()
    {
        var mockFileSystem = new Mock<IFileSystem>();
        IFileSystem fileSystem = mockFileSystem.Object;
        var parser = new CommandParser(fileSystem);
        parser.ParseCommand(@"connect B:\TestLab5 -m local");
        mockFileSystem.Verify(
            x => x.Connect(
                It.Is<string>(path => path == @"B:\TestLab5"),
                It.Is<string>(mode => mode == "local")),
            Times.Once);
    }

    [Fact]
    public void TestDisconnect()
    {
        var mockFileSystem = new Mock<IFileSystem>();
        IFileSystem fileSystem = mockFileSystem.Object;
        var parser = new CommandParser(fileSystem);
        parser.ParseCommand(@"disconnect");
        mockFileSystem.Verify(x => x.Disconnect(), Times.Once);
    }

    [Fact]
    public void TestTreeGoTo()
    {
        var mockFileSystem = new Mock<IFileSystem>();
        IFileSystem fileSystem = mockFileSystem.Object;
        var parser = new CommandParser(fileSystem);
        parser.ParseCommand(@"tree goto B:\TestLab5");
        mockFileSystem.Verify(
            x => x.TreeGoto(
                It.Is<string>(path => path == @"B:\TestLab5")),
            Times.Once);
    }

    [Fact]
    public void TestTreeList()
    {
        var mockFileSystem = new Mock<IFileSystem>();
        IFileSystem fileSystem = mockFileSystem.Object;
        var parser = new CommandParser(fileSystem);
        parser.ParseCommand(@"tree list -d 3");
        mockFileSystem.Verify(
            x => x.TreeList(
                It.Is<int>(depth => depth == 3)),
            Times.Once);
    }

    [Fact]
    public void TestFileShow()
    {
        var mockFileSystem = new Mock<IFileSystem>();
        IFileSystem fileSystem = mockFileSystem.Object;
        var parser = new CommandParser(fileSystem);
        parser.ParseCommand(@"file show B:\TestLab5 -m console");
        mockFileSystem.Verify(
            x => x.ShowFile(
                It.Is<string>(path => path == @"B:\TestLab5"),
                It.Is<string>(mode => mode == "console")),
            Times.Once);
    }

    [Fact]
    public void TestFileMove()
    {
        var mockFileSystem = new Mock<IFileSystem>();
        IFileSystem fileSystem = mockFileSystem.Object;
        var parser = new CommandParser(fileSystem);
        parser.ParseCommand(@"file move B:\TestLab5 B:\TestLab5\fordelete");
        mockFileSystem.Verify(
            x => x.Move(
                It.Is<string>(sourcePath => sourcePath == @"B:\TestLab5"),
                It.Is<string>(destinationPath => destinationPath == @"B:\TestLab5\fordelete")),
            Times.Once);
    }

    [Fact]
    public void TestFileCopy()
    {
        var mockFileSystem = new Mock<IFileSystem>();
        IFileSystem fileSystem = mockFileSystem.Object;
        var parser = new CommandParser(fileSystem);
        parser.ParseCommand(@"file copy B:\TestLab5 B:\TestLab5\fordelete");
        mockFileSystem.Verify(
            x => x.Copy(
                It.Is<string>(sourcePath => sourcePath == @"B:\TestLab5"),
                It.Is<string>(destinationPath => destinationPath == @"B:\TestLab5\fordelete")),
            Times.Once);
    }

    [Fact]
    public void TestFileDelete()
    {
        var mockFileSystem = new Mock<IFileSystem>();
        IFileSystem fileSystem = mockFileSystem.Object;
        var parser = new CommandParser(fileSystem);
        parser.ParseCommand(@"file delete B:\TestLab5");
        mockFileSystem.Verify(
            x => x.Delete(
                It.Is<string>(path => path == @"B:\TestLab5")),
            Times.Once);
    }

    [Fact]
    public void TestFileRename()
    {
        var mockFileSystem = new Mock<IFileSystem>();
        IFileSystem fileSystem = mockFileSystem.Object;
        var parser = new CommandParser(fileSystem);
        parser.ParseCommand(@"file rename B:\TestLab5\test.txt test2.txt");
        mockFileSystem.Verify(
            x => x.Rename(
                It.Is<string>(sourcePath => sourcePath == @"B:\TestLab5\test.txt"),
                It.Is<string>(name => name == @"test2.txt")),
            Times.Once);
    }
}