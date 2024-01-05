using System.ComponentModel.DataAnnotations;

namespace PathTracer;

public class Interval
{
    public double min;
    public double max;

    public Interval()
    {
        min = double.PositiveInfinity;
        max = double.NegativeInfinity;
    }

    public Interval(double _min, double _max)
    {
        min = _min;
        max = _max;
    }

    public bool Contains(double x)
    {
        return min <= x && x <= max;
    }

    public bool Surrounds(double x)
    {
        return min < x && x < max;
    }
}