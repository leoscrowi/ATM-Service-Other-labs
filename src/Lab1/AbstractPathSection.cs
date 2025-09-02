namespace Itmo.ObjectOrientedProgramming.Lab1;

public abstract class AbstractPathSection : IPathSection
{
    protected AbstractPathSection(double distance = 0, double speedLimit = 0)
    {
        Distance = distance;
        SpeedLimit = speedLimit;
    }

    public double Distance { get; }

    public double SpeedLimit { get; }

    protected internal virtual double StartTrain(Train train)
    {
        return train.StartTrain(Distance);
    }
}