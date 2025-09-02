namespace Itmo.ObjectOrientedProgramming.Lab1;

public class ForceMagnetPath : AbstractPathSection
{
    public ForceMagnetPath(double distance, double force) : base(distance, 0)
    {
        Force = force;
    }

    public double Force { get; }

    protected internal override double StartTrain(Train train)
    {
        train.ApplyForce(Force);
        return base.StartTrain(train);
    }
}