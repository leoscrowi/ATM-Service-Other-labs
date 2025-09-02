namespace Itmo.ObjectOrientedProgramming.Lab1;

public class Station : AbstractPathSection
{
    public Station(double speedlimit, double time) : base(0, speedlimit)
    {
        Time = time;
    }

    public double Time { get; }

    protected internal override double StartTrain(Train train)
    {
        if (train.Speed > SpeedLimit)
        {
            throw new Exception("Failure: Speed is greater than speed limit on station");
        }

        return Time + base.StartTrain(train);
    }
}