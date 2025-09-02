namespace Itmo.ObjectOrientedProgramming.Lab1;

public class Path
{
    public Path(double speedLimit)
    {
        SpeedLimit = speedLimit;
    }

    private readonly List<IPathSection> pathSections = new List<IPathSection>();

    public void AddSection(IPathSection section)
    {
        pathSections.Add(section);
    }

    public void DeleteSection(IPathSection section)
    {
        pathSections.Remove(section);
    }

    public void DeleteLastSection()
    {
        pathSections.RemoveAt(pathSections.Count - 1);
    }

    public double SpeedLimit { get; }

    public bool StartTrain(Train train)
    {
        double resultTime = 0;
        foreach (AbstractPathSection pathSection in pathSections.Cast<AbstractPathSection>())
        {
            resultTime += pathSection.StartTrain(train);
        }

        if (train.Speed > SpeedLimit)
        {
            throw new Exception("Failure: Speed is greater than speed limit on end of path");
        }

        Console.WriteLine("Success! Train has passed the path in: " + resultTime);
        return true;
    }
}