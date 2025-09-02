namespace Itmo.ObjectOrientedProgramming.Lab1;

public class Train : ITrain
{
    public Train(double weight, double forceLimit, double accuracy)
    {
        Weight = weight;
        ForceLimit = forceLimit;
        Accuracy = accuracy;
    }

    public double Accuracy { get; }

    public double Weight { get; }

    public double Speed { get; private set; } = 0;

    public double Acceleration { get; private set; } = 0;

    public double ForceLimit { get; }

    protected internal double StartTrain(double distance)
    {
        double time = 0;
        while (distance > 0)
        {
            Speed += Acceleration * Accuracy;
            if (Speed <= 0)
            {
                throw new Exception("Failure: speed can't be negative");
            }

            double completedDistance = Speed * Accuracy;
            distance -= completedDistance;
            time += completedDistance / Speed;
        }

        Console.WriteLine(Speed);
        return time;
    }

    protected internal void ApplyForce(double force)
    {
        if (force > ForceLimit)
        {
            throw new Exception("Failure: force greater than ForceLimit");
        }

        Acceleration = force / Weight;
    }
}