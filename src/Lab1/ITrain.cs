namespace Itmo.ObjectOrientedProgramming.Lab1;

public interface ITrain
{
    double Accuracy { get; }

    double Weight { get; }

    double Speed { get; }

    double Acceleration { get; }

    double ForceLimit { get; }
}