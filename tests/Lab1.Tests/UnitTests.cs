using Itmo.ObjectOrientedProgramming.Lab1;
using Xunit;
using Path = Itmo.ObjectOrientedProgramming.Lab1.Path;

namespace Lab1.Tests;

public class UnitTests
{
    [Fact]
    public void Scenario1()
    {
        var train = new Train(1200, 200, 100);
        var path = new Path(100);
        path.AddSection(new ForceMagnetPath(100, 20));
        path.AddSection(new DefaultMagnetPath(100));
        Assert.True(path.StartTrain(train));
    }

    [Fact]
    public void Scenario2()
    {
        var train = new Train(1200, 200, 100);
        var path = new Path(100);
        path.AddSection(new ForceMagnetPath(100, 1500));
        path.AddSection(new DefaultMagnetPath(100));
        Assert.Throws<Exception>(() => path.StartTrain(train));
    }

    [Fact]
    public void Scenario3()
    {
        var train = new Train(1200, 200, 100);
        var path = new Path(100);
        path.AddSection(new ForceMagnetPath(100, 20));
        path.AddSection(new DefaultMagnetPath(100));
        path.AddSection(new Station(100, 20));
        path.AddSection(new DefaultMagnetPath(100));
        Assert.True(path.StartTrain(train));
    }

    [Fact]
    public void Scenario4()
    {
        var train = new Train(1200, 100000, 100);
        var path = new Path(100);
        path.AddSection(new ForceMagnetPath(100, 1000));
        path.AddSection(new Station(100, 20));
        path.AddSection(new DefaultMagnetPath(100));
        Assert.Throws<Exception>(() => path.StartTrain(train));
    }

    [Fact]
    public void Scenario5()
    {
        var train = new Train(1, 200, 100);
        var path = new Path(100);
        path.AddSection(new ForceMagnetPath(0, 150));
        path.AddSection(new DefaultMagnetPath(100));
        path.AddSection(new Station(100, 20));
        path.AddSection(new DefaultMagnetPath(100));
        Assert.Throws<Exception>(() => path.StartTrain(train));
    }

    [Fact]
    public void Scenario6()
    {
        var train = new Train(1, 2000, 1);
        var path = new Path(1009);
        path.AddSection(new ForceMagnetPath(100, 1000));
        path.AddSection(new DefaultMagnetPath(100));

        path.AddSection(new ForceMagnetPath(100, -1500));
        path.AddSection(new Station(500, 1));

        path.AddSection(new DefaultMagnetPath(0));
        path.AddSection(new ForceMagnetPath(100, 1000));

        path.AddSection(new DefaultMagnetPath(100));
        path.AddSection(new ForceMagnetPath(100, -1500));
        Assert.True(path.StartTrain(train));
    }

    [Fact]
    public void Scenario7()
    {
        var train = new Train(1, 10000, 100);
        var path = new Path(100);
        path.AddSection(new DefaultMagnetPath(100));
        Assert.Throws<Exception>(() => path.StartTrain(train));
    }

    [Fact]
    public void Scenario8()
    {
        var train = new Train(1200, 200, 100);
        var path = new Path(100);
        path.AddSection(new ForceMagnetPath(100, 20));
        path.AddSection(new ForceMagnetPath(100, -40));
        Assert.Throws<Exception>(() => path.StartTrain(train));
    }
}